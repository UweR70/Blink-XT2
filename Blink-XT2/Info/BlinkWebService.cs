namespace Info
{
    public class BlinkWebService
    {

        /*  - This class does not have ANY code.
         *    It is added for documentation purpose only.
         *      
         *   - The below shown code 
         *     1) is the ORIGINAL code from the 
         *          Blink application
         *          App version 6.0.9 (published around End of April 2020)
         *
         *      2) can be found here in JD-GUI
         *          com -> immediasemi -> blink -> api -> retrofit -> BlinkWebService.class
         *
         *      and 
         *      
         *      3) contains ALL 
         *          68 POST 
         *          and 
         *          28 GET       
         *         API URIs the ORIGINAL Blink app knows/uses!
         *         
         *         Search for example "login" in this class and you will find the API URI.
         */

        /*
        package com.immediasemi.blink.api.retrofit;

        import com.immediasemi.blink.api.requests.onboarding.OnboardingCommandUpdate.UpdateCommandRequest;
        import com.immediasemi.blink.createAccount.ValidateEmailBody;
        import com.immediasemi.blink.createAccount.ValidatePasswordBody;
        import com.immediasemi.blink.createAccount.ValidationResponse;
        import com.immediasemi.blink.models.ANetwork;
        import com.immediasemi.blink.models.AccountOptionsResponse;
        import com.immediasemi.blink.models.AccountRetrievalResponse;
        import com.immediasemi.blink.models.AddCameraResponseBody;
        import com.immediasemi.blink.models.AddChimeResponse;
        import com.immediasemi.blink.models.AddOwlResponseBody;
        import com.immediasemi.blink.models.AddSirenResponse;
        import com.immediasemi.blink.models.BatteryUsage;
        import com.immediasemi.blink.models.BlinkData;
        import com.immediasemi.blink.models.CameraConfig;
        import com.immediasemi.blink.models.CameraStatus;
        import com.immediasemi.blink.models.ChangedMedia;
        import com.immediasemi.blink.models.ChangedVideos;
        import com.immediasemi.blink.models.Command;
        import com.immediasemi.blink.models.Commands;
        import com.immediasemi.blink.models.LiveVideoResponse;
        import com.immediasemi.blink.models.MessageResponse;
        import com.immediasemi.blink.models.OwlConfigInfo;
        import com.immediasemi.blink.models.QuickRegionInfo;
        import com.immediasemi.blink.models.SignalStrength;
        import com.immediasemi.blink.models.Siren;
        import com.immediasemi.blink.models.UpdateOwlBody;
        import com.immediasemi.blink.models.User;
        import com.immediasemi.blink.scheduling.Program;
        import com.immediasemi.blink.scheduling.UpdateProgramRequest;
        import com.immediasemi.blink.utils.AutoPurgeSetterBody;
        import com.immediasemi.blink.utils.ClientOption.ClientOptionsResponse;
        import com.immediasemi.blink.utils.SirensReponse;
        import com.immediasemi.blink.utils.VerificationStatusResponse;
        import com.immediasemi.blink.utils.sync.HomescreenV3;
        import java.util.Arrays;
        import java.util.List;
        import javax.annotation.Nullable;
        import okhttp3.ResponseBody;
        import org.threeten.bp.OffsetDateTime;
        import retrofit2.Call;
        import retrofit2.adapter.rxjava.Result;
        import retrofit2.http.Body;
        import retrofit2.http.GET;
        import retrofit2.http.POST;
        import retrofit2.http.Path;
        import retrofit2.http.Query;
        import retrofit2.http.Url;
        import rx.Observable;
        import rx.Single;

        public interface BlinkWebService
        {
            public static final String HTTP_APP_BUILD = "APP-BUILD";
  
            public static final String LIVE_VIEW_TAG = "live_view_stats";
  
            public static final String LOCALE = "LOCALE";
  
            public static final String SYNC_MODULE_TAG = "sync_module";
  
            public static final String TOKEN_AUTH_HEADER = "TOKEN_AUTH";
  
            @GET("https://rest-{tier}.immedia-semi.com/api/v1/account/options")
            Observable<AccountOptionsResponse> accountOptions(@Path("tier") String paramString);

            @POST("https://rest-{tier}.immedia-semi.com/api/v2/notification")
            Observable<Object> acknowledgeNotification(@Body AcknowledgeNotificationBody paramAcknowledgeNotificationBody, @Path("tier") String paramString);

            @POST("https://rest-{tier}.immedia-semi.com/api/v1/networks/{network}/sirens/{siren}/activate/")
            Observable<BlinkData> activateSiren(@Body SirenDurationBody paramSirenDurationBody, @Path("tier") String paramString, @Path("network") long paramLong1, @Path("siren") long paramLong2);

            @POST("https://rest-{tier}.immedia-semi.com/api/v1/networks/{network}/sirens/activate/")
            Observable<BlinkData> activateSirens(@Path("tier") String paramString, @Path("network") long paramLong);

            @POST("https://rest-{tier}.immedia-semi.com/network/{network}/camera/add")
            Observable<AddCameraResponseBody> addCamera(@Body AddCameraBody paramAddCameraBody, @Path("tier") String paramString, @Path("network") long paramLong);

            @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account}/networks/{network}/chimes/add/")
            Observable<AddChimeResponse> addChime(@Body AddSirenNetworkBody paramAddSirenNetworkBody, @Path("tier") String paramString, @Path("account") long paramLong1, @Path("network") long paramLong2);

            @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{accountId}/networks/{networkId}/owls/add")
            Observable<AddOwlResponseBody> addOwl(@Body AddOwlBody paramAddOwlBody, @Path("tier") String paramString, @Path("accountId") long paramLong1, @Path("networkId") long paramLong2);

            @POST("https://rest-{tier}.immedia-semi.com/api/v1/networks/{network}/sirens/add/")
            Observable<AddSirenResponse> addSiren(@Body AddSirenNetworkBody paramAddSirenNetworkBody, @Path("tier") String paramString, @Path("network") long paramLong);

            @GET("https://rest-{tier}.immedia-semi.com/api/v1/version")
            Observable<UpdateStatusBody> appUpdateStatus(@Path("tier") String paramString);

            @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{accountId}/networks/{networkId}/state/{type}")
            Observable<Command> armDisarmNetwork(@Path("tier") String paramString1, @Path("accountId") long paramLong1, @Path("networkId") long paramLong2, @Path("type") String paramString2);

            @GET("https://rest-{tier}.immedia-semi.com/api/v1/camera/usage")
            Observable<BatteryUsage> batteryUsage(@Path("tier") String paramString);

            @GET("https://blinkstatus.net/api/v1/{tier}")
            Observable<StatusBoxBody> blinkStabilityStatus(@Path("tier") String paramString);

            @GET("https://rest-{tier}.immedia-semi.com/network/{network}/camera/{camera}")
            Observable<CameraStatus> cameraCommandStatus(@Path("tier") String paramString, @Path("network") long paramLong1, @Path("camera") long paramLong2);

            @POST("https://rest-{tier}.immedia-semi.com/network/{network}/camera/{camera}/{type}")
            Observable<Command> cameraMotion(@Path("tier") String paramString1, @Path("network") long paramLong1, @Path("camera") long paramLong2, @Path("type") String paramString2);

            @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{accountId}/networks/{networkId}/owls/{owlId}/change_wifi")
            Observable<OwlAddBody> changeOwlWifi(@Body OnboardingStartRequest paramOnboardingStartRequest, @Path("tier") String paramString, @Path("accountId") long paramLong1, @Path("networkId") long paramLong2, @Path("owlId") long paramLong3);

            @POST("https://rest-{tier}.immedia-semi.com/account/change_password/")
            Observable<BlinkData> changePassword(@Body ChangePasswordBody paramChangePasswordBody, @Path("tier") String paramString);

            @GET("https://rest-{tier}.immedia-semi.com/network/{network}/command/{command}")
            Observable<Commands> commandPolling(@Path("tier") String paramString, @Path("network") long paramLong1, @Path("command") long paramLong2);

            @GET("https://rest-{tier}.immedia-semi.com/api/v2/support/ob_phone/")
            Observable<ContactBlink> contactBlink(@Path("tier") String paramString);

            @POST("https://rest-{tier}.immedia-semi.com/api/v1/networks/{network}/programs/create")
            Observable<BlinkData> createProgram(@Body Program paramProgram, @Path("tier") String paramString, @Path("network") long paramLong);

            @POST("https://rest-{tier}.immedia-semi.com/network/add")
            Observable<ANetwork> createSystem(@Body AddNetworkBody paramAddNetworkBody, @Path("tier") String paramString);

            @POST("https://rest-{tier}.immedia-semi.com/api/v1/networks/{network}/sirens/deactivate/")
            Observable<BlinkData> deactivateSirens(@Path("tier") String paramString, @Path("network") long paramLong);

            @POST("https://rest-{tier}.immedia-semi.com/account/delete/")
            Observable<BlinkData> deleteAccount(@Body DeleteAccountBody paramDeleteAccountBody, @Path("tier") String paramString);

            @POST("https://rest-{tier}.immedia-semi.com/network/{network}/camera/{camera}/delete/")
            Observable<BlinkData> deleteCamera(@Path("tier") String paramString, @Path("network") long paramLong1, @Path("camera") long paramLong2);

            @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{accountId}/media/delete")
            Single<Object> deleteMedia(@Body MediaIdListBody paramMediaIdListBody, @Path("accountId") long paramLong, @Path("tier") String paramString);

            @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{accountId}/media/delete")
             Call<Object> deleteMediaCall(@Body MediaIdListBody paramMediaIdListBody, @Path("accountId") long paramLong, @Path("tier") String paramString);

            @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{accountId}/networks/{networkId}/owls/{owlId}/delete")
            Observable<BlinkData> deleteOwl(@Path("tier") String paramString, @Path("accountId") long paramLong1, @Path("networkId") long paramLong2, @Path("owlId") long paramLong3);

            @POST("https://rest-{tier}.immedia-semi.com/api/v1/networks/{network}/programs/{program}/delete")
            Observable<BlinkData> deleteProgram(@Path("tier") String paramString, @Path("network") long paramLong1, @Path("program") long paramLong2);

            @POST("https://rest-{tier}.immedia-semi.com/api/v1/networks/{network}/sirens/{siren}/delete")
            Observable<BlinkData> deleteSirens(@Path("tier") String paramString, @Path("network") long paramLong1, @Path("siren") long paramLong2);

            @POST("https://rest-{tier}.immedia-semi.com/network/{network}/syncmodule/{syncmodule}/delete/")
            Observable<BlinkData> deleteSyncModule(@Path("tier") String paramString1, @Path("network") long paramLong, @Path("syncmodule") String paramString2);

            @POST("https://rest-{tier}.immedia-semi.com/network/{network}/delete")
            Observable<BlinkData> deleteSystem(@Path("tier") String paramString, @Path("network") long paramLong);

            @POST("https://rest-{tier}.immedia-semi.com/api/v1/networks/{network}/programs/{program}/disable")
            Observable<BlinkData> disableProgram(@Path("tier") String paramString, @Path("network") long paramLong1, @Path("program") long paramLong2);

            @GET
            Observable<Result<ResponseBody>> downloadFirmware(@Url String paramString);

            @GET("https://rest-{tier}.immedia-semi.com/api/v1/sync_modules/{serial}/fw_update")
            Observable<Result<ResponseBody>> downloadFirmwareUpdate(@Path("tier") String paramString1, @Path("serial") String paramString2);

            @GET("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{accountId}/owls/{serial}/fw_update")
            Observable<Result<ResponseBody>> downloadOwlFirmwareUpdate(@Path("tier") String paramString1, @Path("accountId") long paramLong, @Path("serial") String paramString2);

            @POST("https://rest-{tier}.immedia-semi.com/api/v1/networks/{network}/programs/{program}/enable")
            Observable<BlinkData> enableProgram(@Path("tier") String paramString, @Path("network") long paramLong1, @Path("program") long paramLong2);

            @GET("https://rest-{tier}.immedia-semi.com/account")
            Observable<AccountRetrievalResponse> getAccount(@Path("tier") String paramString);

            @GET("https://rest-{tier}.immedia-semi.com/network/{network}/camera/{camera}/config")
            Observable<CameraConfig> getCameraConfig(@Path("tier") String paramString, @Path("network") long paramLong1, @Path("camera") long paramLong2);

            @GET("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{accountId}/media/changed")
            Call<ChangedMedia> getChangedMedia(@Path("tier") String paramString, @Path("accountId") long paramLong, @Query("since") OffsetDateTime paramOffsetDateTime, @Query("page") int paramInt);

            @Deprecated
            @GET("https://rest-{tier}.immedia-semi.com/api/v2/videos/changed")
            Call<ChangedVideos> getChangedVideos(@Path("tier") String paramString, @Query("since") OffsetDateTime paramOffsetDateTime, @Query("page") int paramInt);

            @GET("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account}/clients/{client}/options")
            Observable<ClientOptionsResponse> getClientOptions(@Path("tier") String paramString, @Path("account") long paramLong1, @Path("client") long paramLong2);

            @GET("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account}/networks/{network}/cameras/{camera}/motion_regions")
            Observable<MotionRegions> getMotionRegions(@Path("tier") String paramString, @Path("account") long paramLong1, @Path("network") long paramLong2, @Path("camera") long paramLong3);

            @GET("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{accountId}/networks/{networkId}/owls/{owlId}/config")
            Observable<OwlConfigInfo> getOwlConfig(@Path("tier") String paramString, @Path("accountId") long paramLong1, @Path("networkId") long paramLong2, @Path("owlId") long paramLong3);

            @GET("https://rest-{tier}.immedia-semi.com/api/v1/networks/{network}/programs")
            Observable<List<Program>> getPrograms(@Path("network") long paramLong, @Path("tier") String paramString);

            @GET("https://rest-{tier}.immedia-semi.com/regions")
            Observable<QuickRegionInfo> getRegions(@Path("tier") String paramString1, @Query("locale") String paramString2);

            @GET("https://rest-{tier}.immedia-semi.com/api/v1/networks/{network}/sirens/")
            Observable<Siren[]> getSirens(@Path("tier") String paramString, @Path("network") long paramLong);

            @GET("https://rest-{tier}.immedia-semi.com/api/v1/sirens/")
            Observable<SirensReponse> getSirensForAllNetworks(@Path("tier") String paramString);

            @GET("https://rest-{tier}.immedia-semi.com/user")
            Observable<User> getUser(@Path("tier") String paramString);

            @GET("https://rest-{tier}.immedia-semi.com/api/v3/accounts/{account}/homescreen")
            Observable<HomescreenV3> homescreenV3(@Path("tier") String paramString, @Path("account") long paramLong);

            @GET("https://rest-{tier}.immedia-semi.com/api/v1/devices/identify/{serialNumber}")
            Single<IdentifyDeviceResponse> identifyDevice(@Path("tier") String paramString1, @Path("serialNumber") String paramString2);

            @POST("https://rest-{tier}.immedia-semi.com/api/v3/networks/{network}/cameras/{camera}/liveview")
            Observable<LiveVideoResponse> liveView(@Body VideoLiveViewBody paramVideoLiveViewBody, @Path("tier") String paramString, @Path("network") long paramLong1, @Path("camera") long paramLong2);

            @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account}/networks/{network}/owls/{owl}/liveview")
            Observable<PirPollingResponse> liveViewOwl(@Body LiveViewBody paramLiveViewBody, @Path("tier") String paramString, @Path("account") long paramLong1, @Path("network") long paramLong2, @Path("owl") long paramLong3);

            @POST("https://rest-{tier}.immedia-semi.com/api/v5/accounts/{account}/networks/{network}/cameras/{camera}/liveview")
            Observable<PirPollingResponse> liveViewV5(@Body LiveViewBody paramLiveViewBody, @Path("tier") String paramString, @Path("account") long paramLong1, @Path("network") long paramLong2, @Path("camera") long paramLong3);

            @GET("https://rest-{tier}.immedia-semi.com/network/{network}/camera/{camera}/signals")
            Observable<SignalStrength> loadCameraStatus(@Path("tier") String paramString, @Path("network") long paramLong1, @Path("camera") long paramLong2);

            @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/login")
            Observable<LoginResponse> login(@Body LoginBody paramLoginBody, @Path("tier") String paramString);

            @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/login")
            Call<LoginResponse> loginCall(@Body LoginBody paramLoginBody, @Path("tier") String paramString);

            @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/{accountId}/client/{clientId}/logout/")
            Observable<BlinkData> logout(@Path("tier") String paramString, @Path("accountId") Long paramLong1, @Path("clientId") Long paramLong2);

            @POST("https://rest-{tier}.immedia-semi.com/network/{network}/camera/{camera}/status")
            Observable<Command> refreshCameraStatus(@Path("tier") String paramString, @Path("network") long paramLong1, @Path("camera") long paramLong2);

            @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{accountId}/networks/{networkId}/owls/{owlId}/status")
            Observable<Command> refreshOwlStatus(@Path("tier") String paramString, @Path("accountId") long paramLong1, @Path("networkId") long paramLong2, @Path("owlId") long paramLong3);

            @GET("https://rest-prod.immedia-semi.com/regions?locale=US")
            Observable<BlinkData> regions(@Path("tier") String paramString);

            @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/register")
            Observable<RegisterResponse> registerV4(@Body RegisterBody paramRegisterBody, @Path("tier") String paramString);

            @POST("https://rest-{tier}.immedia-semi.com/account/reset_password/")
            Observable<MessageResponse> resetPassword(@Body ResetPasswordBody paramResetPasswordBody, @Path("tier") String paramString);

            @POST("https://rest-{tier}.immedia-semi.com/api/v1/network/{network}/camera/{camera}/calibrate")
            Observable<Command> saveCalibrateTemperature(@Body Calibrate paramCalibrate, @Path("tier") String paramString, @Path("network") long paramLong1, @Path("camera") long paramLong2);

            @POST("https://rest-{tier}.immedia-semi.com/network/{network}/camera/{camera}/update")
            Observable<Command> saveCameraSettings(@Body UpdateCameraBody paramUpdateCameraBody, @Path("tier") String paramString, @Path("network") long paramLong1, @Path("camera") long paramLong2);

            @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{accountId}/networks/{networkId}/owls/{owlId}/config")
            Observable<Command> saveOwlSettings(@Body UpdateOwlBody paramUpdateOwlBody, @Path("tier") String paramString, @Path("accountId") long paramLong1, @Path("networkId") long paramLong2, @Path("owlId") long paramLong3);

            @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account}/clients/{client}/options")
            Observable<BlinkData> sendClientOptions(@Body ClientOptionsResponse paramClientOptionsResponse, @Path("tier") String paramString, @Path("account") long paramLong1, @Path("client") long paramLong2);

            @POST("https://rest-{tier}.immedia-semi.com/app/logs/upload/")
            Observable<BlinkData> sendLogs(@Body LogsBody paramLogsBody, @Path("tier") String paramString);

            @POST("https://rest-{tier}.immedia-semi.com/app/logs/upload/")
            Call<BlinkData> sendLogsCall(@Body LogsBody paramLogsBody, @Path("tier") String paramString);

            @POST("https://rest-{tier}.immedia-semi.com/account/system_offline/{network}")
            Observable<BlinkData> sendSystemOfflineHelpEmaail(@Path("tier") String paramString, @Path("network") long paramLong);

            @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account}/networks/{network}/cameras/{camera}/motion_regions")
            Observable<MotionsRegionsSetResponse> setMotionRegions(@Body MotionRegions paramMotionRegions, @Path("tier") String paramString, @Path("account") long paramLong1, @Path("network") long paramLong2, @Path("camera") long paramLong3);

            @POST("https://rest-{tier}.immedia-semi.com/api/v2/network/{network}/sync_module/{type}")
            Observable<Command> startOnboarding(@Body OnboardingStartRequest paramOnboardingStartRequest, @Path("tier") String paramString1, @Path("network") long paramLong, @Path("type") String paramString2);

            @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account}/networks/{network}/owls/add")
            Observable<OwlAddBody> startOwlOnboarding(@Body OnboardingStartRequest paramOnboardingStartRequest, @Path("tier") String paramString, @Path("account") long paramLong1, @Path("network") long paramLong2);

            @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{accountId}/networks/{networkId}/owls/{owlId}/thumbnail")
            Observable<Command> takeOwlThumbnail(@Path("tier") String paramString, @Path("accountId") long paramLong1, @Path("networkId") long paramLong2, @Path("owlId") long paramLong3);

            @POST("https://rest-{tier}.immedia-semi.com/network/{network}/camera/{camera}/thumbnail")
            Observable<Command> takeThumbnail(@Path("tier") String paramString, @Path("network") long paramLong1, @Path("camera") long paramLong2);

            @POST("https://rest-{tier}.immedia-semi.com/api/v1/network/{network}/camera/{camera}/temp_alert_disable")
            Observable<BlinkData> tempAlertDisable(@Path("tier") String paramString, @Path("network") long paramLong1, @Path("camera") long paramLong2);

            @POST("https://rest-{tier}.immedia-semi.com/api/v1/network/{network}/camera/{camera}/temp_alert_enable")
            Observable<BlinkData> tempAlertEnable(@Path("tier") String paramString, @Path("network") long paramLong1, @Path("camera") long paramLong2);

            @POST("https://rest-{tier}.immedia-semi.com/network/{network}/command/{command}/done/")
            Call<BlinkData> terminateCommand(@Path("network") long paramLong1, @Path("command") long paramLong2, @Path("tier") String paramString);

            @POST("https://rest-{tier}.immedia-semi.com/network/{network}/command/{command}/update/")
            Observable<BlinkData> terminateOnboardingCommand(@Body TerminateOnboardingBody paramTerminateOnboardingBody, @Path("tier") String paramString, @Path("network") long paramLong1, @Path("command") long paramLong2);

            @POST("https://rest-{tier}.immedia-semi.com/account/update")
            Observable<BlinkData> updateAccount(@Body UpdateAccountBody paramUpdateAccountBody, @Path("tier") String paramString);

            @GET("https://rest-{tier}.immedia-semi.com/api/v1/fw/app/update_check")
            Observable<UpdateCheckBodyReceiveBody> updateCheck(@Path("tier") String paramString1, @Query("serial") String paramString2);

            @POST("https://rest-{tier}.immedia-semi.com/network/{network}/command/{command}/update/")
            Observable<BlinkData> updateCommand(@Body UpdateCommandRequest paramUpdateCommandRequest, @Path("network") long paramLong1, @Path("command") long paramLong2, @Path("tier") String paramString);

            @POST("https://rest-{tier}.immedia-semi.com/network/{network}/command/{command}/update/")
            Call<BlinkData> updateCommandSync(@Body UpdateCommandRequest paramUpdateCommandRequest, @Path("network") long paramLong1, @Path("command") long paramLong2, @Path("tier") String paramString);

            @POST("https://rest-{tier}.immedia-semi.com/network/{network}/update")
            Observable<BlinkData> updateNetworkSaveAllLiveViews(@Body UpdateNetworkSaveAllLiveViews paramUpdateNetworkSaveAllLiveViews, @Path("tier") String paramString, @Path("network") long paramLong);

            @POST("https://rest-{tier}.immedia-semi.com/api/v1/networks/{network}/programs/{program}/update")
            Observable<BlinkData> updateProgram(@Body UpdateProgramRequest paramUpdateProgramRequest, @Path("tier") String paramString, @Path("network") long paramLong1, @Path("program") long paramLong2);

            @POST("https://rest-{tier}.immedia-semi.com/api/v1/networks/{network}/sirens/{siren}/update")
            Observable<BlinkData> updateSiren(@Body SirenNameBody paramSirenNameBody, @Path("tier") String paramString, @Path("network") long paramLong1, @Path("siren") long paramLong2);

            @POST("https://rest-{tier}.immedia-semi.com/api/v1/networks/{network}/sirens/update")
            Observable<Siren[]> updateSirens(@Body SirenDurationBody paramSirenDurationBody, @Path("tier") String paramString, @Path("network") long paramLong);

            @POST("https://rest-{tier}.immedia-semi.com/network/{network}/update")
            Observable<BlinkData> updateSystem(@Body UpdateSystemNameBody paramUpdateSystemNameBody, @Path("tier") String paramString, @Path("network") long paramLong);

            @POST("https://rest-{tier}.immedia-semi.com/network/{network}/update")
            Observable<BlinkData> updateTimezone(@Body UpdateTimezoneBody paramUpdateTimezoneBody, @Path("tier") String paramString, @Path("network") long paramLong);

            @POST("https://rest-{tier}.immedia-semi.com/api/v3/account/validate_email")
            Single<ValidationResponse> validateEmailAddress(@Body ValidateEmailBody paramValidateEmailBody, @Path("tier") String paramString);

            @POST("https://rest-{tier}.immedia-semi.com/api/v3/account/validate_password")
            Single<ValidationResponse> validatePassword(@Body ValidatePasswordBody paramValidatePasswordBody, @Path("tier") String paramString);

            @POST("https://rest-{tier}.immedia-semi.com/api/v3/account/{account}/resend_account_verification/")
            Observable<ResendPinEmailResponse> verificationEmail(@Path("tier") String paramString, @Path("account") long paramLong);

            @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/{account}/client/{client}/resend_client_verification/")
            Observable<ResendPinEmailResponse> verificationPinClient(@Path("tier") String paramString, @Path("account") long paramLong1, @Path("client") long paramLong2);

            @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/{account}/resend_account_verification/")
            Observable<ResendPinEmailResponse> verificationPinEmail(@Path("tier") String paramString, @Path("account") long paramLong);

            @GET("https://rest-{tier}.immedia-semi.com/api/v3/account/{account_id}/status")
            Observable<VerificationStatusResponse> verificationStatusEndpoint(@Path("tier") String paramString, @Path("account_id") long paramLong);

            @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/{account}/pin/verify/")
            Observable<PinVerificationResponse> verifyAccountPIN(@Path("tier") String paramString, @Path("account") long paramLong, @Body VerifyPinBody paramVerifyPinBody);

            @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/{account}/client/{client}/pin/verify/")
            Observable<PinVerificationResponse> verifyClientPIN(@Path("tier") String paramString, @Path("account") long paramLong1, @Path("client") long paramLong2, @Body VerifyPinBody paramVerifyPinBody);

            @POST("https://rest-{tier}.immedia-semi.com/api/v1/account/video_options")
            Observable<Object> video_options_setter(@Body AutoPurgeSetterBody paramAutoPurgeSetterBody, @Path("tier") String paramString);

            public static class AddSirenNetworkBody
            {
                public String serial;
            }

            public static class Calibrate
            {
                public final int current_temp;

                public final int temp_max;

                public final int temp_min;

                public Calibrate(int param1Int1, int param1Int2, int param1Int3)
                {
                    this.temp_max = param1Int1;
                    this.temp_min = param1Int2;
                    this.current_temp = param1Int3;
                }
            }

            public static class ContactBlink
            {
                public String phone_number;
            }

            public static class LiveViewBody
            {
                public String intent;

                public String motion_event_start_time = null;
            }

            public static class LogsBody
            {
                public long command_id;

                public String log;

                public String tag;
            }

            public static class MediaIdListBody
            {
                private final List<Long> media_list;

                public MediaIdListBody(List<Long> param1List)
                {
                    this.media_list = param1List;
                }

                public MediaIdListBody(Long...param1VarArgs)
                {
                    this.media_list = Arrays.asList(param1VarArgs);
                }
            }

            public static class MotionRegions
            {
                public int[] advanced_motion_regions = new int[25];

                public int motion_regions;
            }

            public static class MotionsRegionsSetResponse
            {
                public long id;

                public String message;
            }

            public static class OnboardingStartRequest
            {
                String serial;

                public OnboardingStartRequest(String param1String)
                {
                    this.serial = param1String;
                }

                public String getSerial()
                {
                    return this.serial;
                }

                public void setSerial(String param1String)
                {
                    this.serial = param1String;
                }
            }

            public static class Owl
            {
                public long id;

                public BlinkWebService.Session_keys session_keys;

                public String token;
            }

            public static class OwlAddBody
            {
                public long id;

                public BlinkWebService.Owl owl;
            }

            public static class PinVerificationResponse
            {
                public int code;

                public String message;

                public boolean require_new_pin;

                public boolean valid;
            }

            public static class PirOptions
            {
                public boolean poor_connection = false;
            }

            public static class PirPollingResponse
            {
                public long command_id;

                public int continue_interval = 30;

                public int continue_warning = 10;

                public int duration = 300;

                public boolean join_available;

                public String join_state;

                public long media_id;

                public boolean new_command = false;

                public BlinkWebService.PirOptions options;

                public String server;

                public long video_id;
            }

            public static class ResendPinEmailResponse
            {
                @Nullable
              public Integer allow_pin_resend_seconds;
            }

            public static class Session_keys
            {
                public String encrypted_session_key;

                public String session_key;
            }

            public static class SirenDurationBody
            {
                public int duration;

                public SirenDurationBody(int param1Int)
                {
                    this.duration = param1Int;
                }
            }

            public static class SirenNameBody
            {
                public String name;

                public SirenNameBody(String param1String)
                {
                    this.name = param1String;
                }
            }

            public static class Token
            {
                public String auth;
            }

            public static class UpdateCheckBodyReceiveBody
            {
                String fw_min_version;

                public String fw_url;

                String fw_version;

                public float getFw_min_version()
                {
                    return Float.valueOf(this.fw_min_version.replaceAll("[^\\d.]+|\\.(?!\\d)", "")).floatValue();
                }

                public float getFw_version()
                {
                    return Float.valueOf(this.fw_version.replaceAll("[^\\d.]+|\\.(?!\\d)", "")).floatValue();
                }
            }

            public static class UpdateNetworkSaveAllLiveViews
            {
                public boolean lv_save;
            }

            public static class UpdateStatusBody
            {
                private int code;

                private String message;

                private boolean update_available;

                private boolean update_required;

                public String getMessage()
                {
                    return this.message;
                }

                public boolean isUpdate_available()
                {
                    return this.update_available;
                }

                public boolean isUpdate_required()
                {
                    return this.update_required;
                }

                public void setCode(int param1Int)
                {
                    this.code = param1Int;
                }
            }

            public static class UpdateTimezoneBody
            {
                public String description;

                public boolean dst;

                public String locale;

                public String name;

                public String time_zone;
            }

            public static class VerifyPinBody
            {
                public String pin;

                public VerifyPinBody(String param1String)
                {
                    this.pin = param1String;
                }
            }

            public static class VideoLiveViewBody
            {
                public final long id;

                public final long network;

                public final long type;

                public VideoLiveViewBody(long param1Long1, long param1Long2, long param1Long3)
                {
                    this.network = param1Long1;
                    this.id = param1Long2;
                    this.type = param1Long3;
                }
            }
        }
        */
    }
}
