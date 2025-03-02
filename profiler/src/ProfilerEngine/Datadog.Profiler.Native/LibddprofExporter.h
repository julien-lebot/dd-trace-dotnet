// Unless explicitly stated otherwise all files in this repository are licensed under the Apache 2 License.
// This product includes software developed at Datadog (https://www.datadoghq.com/). Copyright 2022 Datadog, Inc.

#pragma once

#include "IConfiguration.h"
#include "IExporter.h"
#include "IUpscaleProvider.h"
#include "MetricsRegistry.h"
#include "Sample.h"
#include "TagsHelper.h"

#include <mutex>

extern "C"
{
#include "datadog/profiling.h"
}

#include <forward_list>
#include <memory>
#include <string_view>
#include <unordered_map>
#include <vector>
#include <optional>

class Sample;
class IMetricsSender;
class IApplicationStore;
class IRuntimeInfo;
class IEnabledProfilers;
class IAllocationsRecorder;
class IProcessSamplesProvider;
class IMetadataProvider;

class LibddprofExporter : public IExporter
{
public:
    LibddprofExporter(
        std::vector<SampleValueType> sampleTypeDefinitions,
        IConfiguration* configuration,
        IApplicationStore* applicationStore,
        IRuntimeInfo* runtimeInfo,
        IEnabledProfilers* enabledProfilers,
        MetricsRegistry& metricsRegistry,
        IMetadataProvider* metadataProvider,
        IAllocationsRecorder* allocationsRecorder
        );
    ~LibddprofExporter() override;
    bool Export() override;
    void Add(std::shared_ptr<Sample> const& sample) override;
    void SetEndpoint(const std::string& runtimeId, uint64_t traceId, const std::string& endpoint) override;
    void RegisterUpscaleProvider(IUpscaleProvider* provider) override;
    void RegisterProcessSamplesProvider(ISamplesProvider* provider) override;

private:
    class SerializedProfile
    {
    public:
        SerializedProfile(struct ddog_prof_Profile* profile);
        ~SerializedProfile();

        ddog_Vec_U8 GetBuffer() const;
        ddog_Timespec GetStart() const;
        ddog_Timespec GetEnd() const;
        ddog_prof_ProfiledEndpointsStats* GetEndpointsStats() const;

        bool IsValid() const;

    private:
        ddog_prof_Profile_SerializeResult _encodedProfile;
    };

    class Tags
    {
    public:
        Tags();
        ~Tags() noexcept;

        Tags(const Tags&) = delete;
        Tags& operator=(const Tags&) = delete;

        Tags(Tags&&) noexcept;
        Tags& operator=(Tags&&) noexcept;

        void Add(std::string const& name, std::string const& value);

        const ddog_Vec_Tag* GetFfiTags() const;

    private:
        ddog_Vec_Tag _ffiTags;
    };

    class ProfileAutoDelete
    {
    public:
        ProfileAutoDelete(struct ddog_prof_Profile* profile);
        ~ProfileAutoDelete();

    private:
        struct ddog_prof_Profile* _profile;
    };

    class ProfileInfo
    {
    public:
        ProfileInfo();
    public:
        ddog_prof_Profile* profile;
        std::int32_t samplesCount;
        std::int32_t exportsCount;
        std::mutex lock;
    };

    class ProfileInfoScope
    {
    public:
        ProfileInfoScope(ProfileInfo& profileInfo);

        ProfileInfo& profileInfo;

    private:
        std::lock_guard<std::mutex> _lockGuard;
    };

    static Tags CreateTags(
        IConfiguration* configuration,
        IRuntimeInfo* runtimeInfo,
        IEnabledProfilers* enabledProfilers);

    static ddog_prof_Exporter* CreateExporter(const ddog_Vec_Tag* tags, ddog_Endpoint endpoint);
    ddog_prof_Profile* CreateProfile();

    void AddProcessSamples(ddog_prof_Profile* profile, std::list<std::shared_ptr<Sample>> const& samples);
    void Add(ddog_prof_Profile* profile, std::shared_ptr<Sample> const& sample);

    ddog_prof_Exporter_Request* CreateRequest(SerializedProfile const& encodedProfile, ddog_prof_Exporter* exporter, const Tags& additionalTags) const;
    ddog_Endpoint CreateEndpoint(IConfiguration* configuration);
    ProfileInfoScope GetOrCreateInfo(std::string_view runtimeId);

    void ExportToDisk(const std::string& applicationName, SerializedProfile const& encodedProfile, int idx);
    void SaveJsonToDisk(const std::string prefix, const std::string& content) const;

    // we *must* pass the reference to the pointer
    // the Send function in rust takes the ownership, free the memory and set the pointer to null (avoid double free)
    static bool Send(ddog_prof_Exporter_Request*& request, ddog_prof_Exporter* exporter) ;
    static void AddUpscalingRules(ddog_prof_Profile* profile, std::vector<UpscalingInfo> const& upscalingInfos);
    static fs::path CreatePprofOutputPath(IConfiguration* configuration);

    std::string GenerateFilePath(const std::string& applicationName, int idx, const std::string& extension) const;
    std::string CreateMetricsFileContent() const;
    std::vector<UpscalingInfo> GetUpscalingInfos();
    std::list<std::shared_ptr<Sample>> GetProcessSamples();
    std::optional<ProfileInfoScope> GetInfo(const std::string& runtimeId);
    std::string GetMetadata() const;

    static tags CommonTags;
    static std::string const ProcessId;
    static int const RequestTimeOutMs;
    static std::string const LibraryName;
    static std::string const LibraryVersion;
    static std::string const LanguageFamily;
    static std::string const MetricsFilename;
    static std::string const ProfileExtension;
    static std::string const AllocationsExtension;

    // TODO: this should be passed in the constructor to avoid overwriting
    //       the .pprof generated by the managed side
    static std::string const RequestFileName;
    static std::string const ProfilePeriodType;
    static std::string const ProfilePeriodUnit;

    std::vector<SampleValueType> _sampleTypeDefinitions;
    fs::path _pprofOutputPath;

    std::vector<ddog_prof_Location> _locations;
    std::vector<ddog_prof_Line> _lines;
    std::string _agentUrl;
    std::size_t _locationsAndLinesSize;

    // for each application, keep track of a profile, a samples count since the last export and an export count
    std::unordered_map<std::string_view, ProfileInfo> _perAppInfo;
    ddog_Endpoint _endpoint;
    Tags _exporterBaseTags;
    IApplicationStore* const _applicationStore;

    std::mutex _perAppInfoLock;
    MetricsRegistry& _metricsRegistry;
    fs::path _metricsFileFolder;
    IAllocationsRecorder* _allocationsRecorder;
    std::vector<IUpscaleProvider*> _upscaledProviders;
    std::vector<ISamplesProvider*> _processSamplesProviders;
    IMetadataProvider* _metadataProvider;

public:  // for tests
    static std::string GetEnabledProfilersTag(IEnabledProfilers* enabledProfilers);
};