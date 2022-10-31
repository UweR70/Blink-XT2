namespace Info
{
    class BlinkWebService_6_18_0
    {

        /*  - This class does not have ANY code.
         *    It is added for documentation purpose only.
         *      
         *   - The below shown code 
         *     1) is the ORIGINAL code from the 
         *          Blink application
         *          App version 6.18.0 (published October, 11th 2022)
         *
         *      2) can be found here in JD-GUI
         *          com -> immediasemi -> blink -> api -> retrofit -> BlinkWebService.class
         *
         *      and 
         *      
         *      3) contains ALL 
         *          88 POST 
         *          and 
         *          26 GET       
         *         API URIs the ORIGINAL Blink app knows/uses!
         *         
         *         Search for example "login" in this class and you will find the API URI.
         */

        /*
        package com.immediasemi.blink.api.retrofit;

    import com.github.michaelbull.result.Result;
    import com.immediasemi.blink.api.requests.onboarding.OnboardingCommandUpdate.UpdateCommandRequest;
    import com.immediasemi.blink.createaccount.ValidateEmailBody;
    import com.immediasemi.blink.createaccount.ValidatePasswordBody;
    import com.immediasemi.blink.createaccount.ValidationResponse;
    import com.immediasemi.blink.models.ANetwork;
    import com.immediasemi.blink.models.AccountOptionsResponse;
    import com.immediasemi.blink.models.AddCameraResponseBody;
    import com.immediasemi.blink.models.AddSirenResponse;
    import com.immediasemi.blink.models.BatteryUsage;
    import com.immediasemi.blink.models.BlinkData;
    import com.immediasemi.blink.models.CameraConfig;
    import com.immediasemi.blink.models.ChangedMedia;
    import com.immediasemi.blink.models.Command;
    import com.immediasemi.blink.models.Commands;
    import com.immediasemi.blink.models.OwlConfigInfo;
    import com.immediasemi.blink.models.QuickRegionInfo;
    import com.immediasemi.blink.models.SignalStrength;
    import com.immediasemi.blink.models.Siren;
    import com.immediasemi.blink.models.UpdateOwlBody;
    import com.immediasemi.blink.scheduling.Program;
    import com.immediasemi.blink.scheduling.UpdateProgramRequest;
    import com.immediasemi.blink.utils.AutoPurgeSetterBody;
    import com.immediasemi.blink.utils.LinkUnLinkAmazonAccountResponse;
    import com.immediasemi.blink.utils.MapLinkBody;
    import com.immediasemi.blink.utils.SirensReponse;
    import com.immediasemi.blink.utils.SubscriptionPollingResponse;
    import com.immediasemi.blink.utils.VerifyAmazonLinkStatusBody;
    import com.immediasemi.blink.utils.VerifyLinkAccountBody;
    import com.immediasemi.blink.utils.clientoption.ClientOptionsResponse;
    import com.immediasemi.blink.utils.sync.Account;
    import com.immediasemi.blink.utils.sync.HomescreenV3;
    import java.util.List;
    import kotlin.Metadata;
    import kotlin.Unit;
    import kotlin.coroutines.Continuation;
    import okhttp3.ResponseBody;
    import org.threeten.bp.OffsetDateTime;
    import retrofit2.Call;
    import retrofit2.adapter.rxjava.Result;
    import retrofit2.http.Body;
    import retrofit2.http.DELETE;
    import retrofit2.http.GET;
    import retrofit2.http.POST;
    import retrofit2.http.Path;
    import retrofit2.http.Query;
    import retrofit2.http.Url;
    import rx.Observable;
    import rx.Single;

    @Metadata(bv = {1, 0, 3}, d1 = {"\000\005\n\002\030\002\n\002\020\000\n\000\n\002\030\002\n\002\030\002\n\002\b\002\n\002\030\002\n\000\n\002\030\002\n\000\n\002\030\002\n\000\n\002\020\t\n\002\b\003\n\002\030\002\n\000\n\002\030\002\n\000\n\002\030\002\n\000\n\002\030\002\n\000\n\002\030\002\n\000\n\002\030\002\n\002\b\003\n\002\020\016\n\000\n\002\030\002\n\000\n\002\030\002\n\000\n\002\030\002\n\002\b\005\n\002\030\002\n\002\020\002\n\002\020\003\n\002\030\002\n\002\b\002\n\002\030\002\n\002\b\002\n\002\030\002\n\000\n\002\030\002\n\000\n\002\030\002\n\002\b\002\n\002\030\002\n\002\b\002\n\002\030\002\n\000\n\002\030\002\n\002\b\002\n\002\030\002\n\002\b\002\n\002\030\002\n\002\b\002\n\002\030\002\n\000\n\002\030\002\n\000\n\002\030\002\n\002\b\003\n\002\030\002\n\002\b\005\n\002\030\002\n\000\n\002\030\002\n\002\b\t\n\002\030\002\n\002\030\002\n\002\b\t\n\002\030\002\n\002\b\002\n\002\030\002\n\000\n\002\030\002\n\000\n\002\030\002\n\000\n\002\030\002\n\000\n\002\030\002\n\000\n\002\020\b\n\000\n\002\030\002\n\002\b\003\n\002\030\002\n\002\b\003\n\002\030\002\n\002\b\002\n\002\030\002\n\000\n\002\030\002\n\000\n\002\030\002\n\000\n\002\020 \n\000\n\002\030\002\n\002\b\003\n\002\020\021\n\002\030\002\n\000\n\002\030\002\n\000\n\002\030\002\n\002\b\003\n\002\030\002\n\000\n\002\030\002\n\000\n\002\030\002\n\000\n\002\030\002\n\000\n\002\030\002\n\002\b\002\n\002\030\002\n\000\n\002\030\002\n\002\b\002\n\002\030\002\n\002\030\002\n\002\b\003\n\002\030\002\n\002\030\002\n\002\b\003\n\002\030\002\n\000\n\002\030\002\n\002\030\002\n\002\b\006\n\002\030\002\n\002\b\002\n\002\030\002\n\002\b\003\n\002\030\002\n\002\b\002\n\002\030\002\n\002\b\002\n\002\030\002\n\002\b\003\n\002\030\002\n\002\b\003\n\002\030\002\n\002\030\002\n\002\b\002\n\002\030\002\n\002\030\002\n\002\b\005\n\002\030\002\n\002\030\002\n\002\b\t\n\002\030\002\n\002\b\003\n\002\030\002\n\002\b\003\n\002\030\002\n\000\n\002\030\002\n\000\n\002\030\002\n\002\b\003\n\002\030\002\n\002\b\002\n\002\030\002\n\002\b\002\n\002\030\002\n\002\b\002\n\002\030\002\n\002\b\003\n\002\030\002\n\002\b\002\n\002\030\002\n\002\b\002\n\002\030\002\n\002\030\002\n\000\n\002\030\002\n\002\b\004\n\002\030\002\n\000\n\002\030\002\n\002\b\005\n\002\030\002\n\002\b\002\bf\030\000 \0022\0020\001:\002\002J\016\020\002\032\b\022\004\022\0020\0040\003H'J\030\020\005\032\b\022\004\022\0020\0010\0032\b\b\001\020\006\032\0020\007H'J,\020\b\032\b\022\004\022\0020\t0\0032\b\b\001\020\n\032\0020\0132\b\b\001\020\f\032\0020\r2\b\b\001\020\016\032\0020\rH'J\030\020\017\032\b\022\004\022\0020\t0\0032\b\b\001\020\f\032\0020\rH'J\"\020\020\032\b\022\004\022\0020\0210\0032\b\b\001\020\022\032\0020\0232\b\b\001\020\f\032\0020\rH'J\"\020\024\032\b\022\004\022\0020\0250\0032\b\b\001\020\026\032\0020\0272\b\b\001\020\f\032\0020\rH'J\016\020\030\032\b\022\004\022\0020\0310\003H'J,\020\032\032\b\022\004\022\0020\0330\0032\b\b\001\020\034\032\0020\r2\b\b\001\020\035\032\0020\r2\b\b\001\020\036\032\0020\037H'J\016\020 \032\b\022\004\022\0020!0\003H'J\016\020\"\032\b\022\004\022\0020#0\003H'J,\020$\032\b\022\004\022\0020\0330%2\b\b\001\020&\032\0020\r2\b\b\001\020\f\032\0020\r2\b\b\001\020'\032\0020\rH'J,\020(\032\b\022\004\022\0020\0330\0032\b\b\001\020\f\032\0020\r2\b\b\001\020)\032\0020\r2\b\b\001\020\036\032\0020\037H'J1\020*\032\030\022\004\022\0020,\022\004\022\0020-0+j\b\022\004\022\0020,`.2\b\b\001\020\034\032\0020\rH\001\000\006\002\020/J,\0200\032\b\022\004\022\002010\0032\b\b\001\020\034\032\0020\r2\b\b\001\0202\032\0020\r2\b\b\001\0203\032\00204H'J6\0205\032\b\022\004\022\002060\0032\b\b\001\0207\032\002082\b\b\001\020\034\032\0020\r2\b\b\001\020\035\032\0020\r2\b\b\001\0209\032\0020\rH'J,\020:\032\b\022\004\022\0020\t0\0032\b\b\001\020\034\032\0020\r2\b\b\001\0202\032\0020\r2\b\b\001\020\006\032\0020;H'J\030\020<\032\b\022\004\022\0020\t0\0032\b\b\001\020\006\032\0020;H'JO\020=\032\030\022\004\022\0020>\022\004\022\0020-0+j\b\022\004\022\0020>`.2\b\b\001\020\034\032\0020\r2\b\b\001\020?\032\0020\r2\b\b\001\0202\032\0020\r2\b\b\001\020\006\032\0020@H\001\000\006\002\020AJ\"\020B\032\b\022\004\022\0020C0\0032\b\b\001\020\035\032\0020\r2\b\b\001\020D\032\0020\rH'J\016\020E\032\b\022\004\022\0020F0\003H'J\"\020G\032\b\022\004\022\0020\t0\0032\b\b\001\020H\032\0020I2\b\b\001\020\f\032\0020\rH'J\030\020J\032\b\022\004\022\0020K0\0032\b\b\001\020L\032\0020MH'J\030\020N\032\b\022\004\022\0020\t0\0032\b\b\001\020\f\032\0020\rH'J\030\020O\032\b\022\004\022\0020\t0\0032\b\b\001\020P\032\0020QH'J\"\020R\032\b\022\004\022\0020\t0\0032\b\b\001\020\f\032\0020\r2\b\b\001\020)\032\0020\rH'J@\020S\032\b\022\004\022\0020\0330%2\b\b\001\020&\032\0020\r2\b\b\001\020\f\032\0020\r2\b\b\001\020'\032\0020\r2\b\b\001\020T\032\0020\r2\b\b\001\020U\032\0020\rH'J\"\020V\032\b\022\004\022\0020\0010W2\b\b\001\020X\032\0020Y2\b\b\001\020\034\032\0020\rH'J,\020Z\032\b\022\004\022\0020\t0\0032\b\b\001\020\034\032\0020\r2\b\b\001\020\f\032\0020\r2\b\b\001\0209\032\0020\rH'J\"\020[\032\b\022\004\022\0020\t0\0032\b\b\001\020\f\032\0020\r2\b\b\001\020H\032\0020\rH'J\"\020\\\032\b\022\004\022\0020\t0\0032\b\b\001\020\f\032\0020\r2\b\b\001\020\016\032\0020\rH'J\"\020]\032\b\022\004\022\0020\t0\0032\b\b\001\020\f\032\0020\r2\b\b\001\020^\032\0020\037H'J\030\020_\032\b\022\004\022\0020\t0\0032\b\b\001\020\f\032\0020\rH'J\"\020`\032\b\022\004\022\0020\t0\0032\b\b\001\020\f\032\0020\r2\b\b\001\020H\032\0020\rH'J,\020a\032\b\022\004\022\0020\t0%2\b\b\001\020&\032\0020\r2\b\b\001\020\f\032\0020\r2\b\b\001\020'\032\0020\rH'J\036\020b\032\016\022\n\022\b\022\004\022\0020d0c0\0032\b\b\001\020e\032\0020\037H'J\036\020f\032\016\022\n\022\b\022\004\022\0020d0c0\0032\b\b\001\020g\032\0020\037H'J(\020h\032\016\022\n\022\b\022\004\022\0020d0c0\0032\b\b\001\020\034\032\0020\r2\b\b\001\020g\032\0020\037H'J,\020i\032\b\022\004\022\0020\0330%2\b\b\001\020&\032\0020\r2\b\b\001\020\f\032\0020\r2\b\b\001\020'\032\0020\rH'J\"\020j\032\b\022\004\022\0020\t0\0032\b\b\001\020\f\032\0020\r2\b\b\001\020H\032\0020\rH'J,\020k\032\b\022\004\022\0020\t0%2\b\b\001\020&\032\0020\r2\b\b\001\020\f\032\0020\r2\b\b\001\020'\032\0020\rH'J,\020l\032\b\022\004\022\0020\0330%2\b\b\001\020&\032\0020\r2\b\b\001\020\f\032\0020\r2\b\b\001\020'\032\0020\rH'J\"\020m\032\b\022\004\022\0020n0\0032\b\b\001\020\034\032\0020\r2\b\b\001\0202\032\0020\rH'J\030\020o\032\b\022\004\022\0020n0\0032\b\b\001\020p\032\0020qH'J1\020r\032\030\022\004\022\0020s\022\004\022\0020-0+j\b\022\004\022\0020s`.2\b\b\001\020\034\032\0020\rH\001\000\006\002\020/J\"\020t\032\b\022\004\022\0020u0\0032\b\b\001\020\f\032\0020\r2\b\b\001\020)\032\0020\rH'J,\020v\032\b\022\004\022\0020w0W2\b\b\001\020\034\032\0020\r2\b\b\001\020x\032\0020y2\b\b\001\020z\032\0020{H'J\"\020|\032\b\022\004\022\0020}0\0032\b\b\001\020&\032\0020\r2\b\b\001\020~\032\0020\rH'J@\020\032\b\022\004\022\0020\0330%2\b\b\001\020&\032\0020\r2\b\b\001\020\f\032\0020\r2\b\b\001\020'\032\0020\r2\b\b\001\020T\032\0020\r2\b\b\001\020U\032\0020\rH'J9\020\001\032\t\022\005\022\0030\0010%2\b\b\001\020&\032\0020\r2\b\b\001\020\f\032\0020\r2\b\b\001\020'\032\0020\r2\t\b\001\020\001\032\0020\rH'J-\020\001\032\b\022\004\022\0020\0330%2\b\b\001\020&\032\0020\r2\b\b\001\020\f\032\0020\r2\b\b\001\020'\032\0020\rH'J+\020\001\032\032\022\005\022\0030\001\022\004\022\0020-0+j\t\022\005\022\0030\001`.H\001\000\006\003\020\001J4\020\001\032\032\022\005\022\0030\001\022\004\022\0020-0+j\t\022\005\022\0030\001`.2\b\b\001\020\034\032\0020\rH\001\000\006\002\020/J.\020\001\032\t\022\005\022\0030\0010%2\b\b\001\020&\032\0020\r2\b\b\001\020\f\032\0020\r2\b\b\001\020'\032\0020\rH'J.\020\001\032\t\022\005\022\0030\0010\0032\b\b\001\020\034\032\0020\r2\b\b\001\020\035\032\0020\r2\b\b\001\0209\032\0020\rH'J \020\001\032\017\022\013\022\t\022\004\022\0020I0\0010\0032\b\b\001\020\f\032\0020\rH'J6\020\001\032\032\022\005\022\0030\001\022\004\022\0020-0+j\t\022\005\022\0030\001`.2\t\b\001\020\001\032\0020\037H\001\000\006\003\020\001J!\020\001\032\020\022\f\022\n\022\005\022\0030\0010\0010\0032\b\b\001\020\f\032\0020\rH'J\020\020\001\032\t\022\005\022\0030\0010\003H'J@\020\001\032\032\022\005\022\0030\001\022\004\022\0020-0+j\t\022\005\022\0030\001`.2\b\b\001\020\034\032\0020\r2\t\b\001\020\001\032\0020\rH\001\000\006\003\020\001J4\020\001\032\032\022\005\022\0030\001\022\004\022\0020-0+j\t\022\005\022\0030\001`.2\b\b\001\020\034\032\0020\rH\001\000\006\002\020/J?\020\001\032\032\022\005\022\0030\001\022\004\022\0020-0+j\t\022\005\022\0030\001`.2\b\b\001\020\034\032\0020\r2\b\b\001\020D\032\0020\rH\001\000\006\003\020\001J.\020\001\032\t\022\005\022\0030\0010\0032\b\b\001\020&\032\0020\r2\b\b\001\020\f\032\0020\r2\b\b\001\020)\032\0020\rH'J\032\020\001\032\t\022\005\022\0030\0010%2\b\b\001\020&\032\0020\rH'J\033\020\001\032\t\022\005\022\0030\0010%2\t\b\001\020\001\032\0020\037H'JC\020\001\032\032\022\005\022\0030\001\022\004\022\0020-0+j\t\022\005\022\0030\001`.2\f\b\001\020\001\032\005\030\0010\0012\b\b\001\020&\032\0020\rH\001\000\006\003\020\001JN\020\001\032\032\022\005\022\0030\001\022\004\022\0020-0+j\t\022\005\022\0030\001`.2\n\b\001\020\001\032\0030\0012\b\b\001\020&\032\0020\r2\013\b\001\020\001\032\004\030\0010\037H\001\000\006\003\020\001J:\020\001\032\t\022\005\022\0030\0010\0032\t\b\001\020\006\032\0030\0012\b\b\001\020&\032\0020\r2\b\b\001\020\f\032\0020\r2\t\b\001\020\001\032\0020\rH'J9\020\001\032\t\022\005\022\0030\0010\0032\t\b\001\020\006\032\0030\0012\b\b\001\020&\032\0020\r2\b\b\001\020\f\032\0020\r2\b\b\001\020)\032\0020\rH'J$\020\001\032\t\022\005\022\0030\0010\0032\b\b\001\020\f\032\0020\r2\b\b\001\020)\032\0020\rH'J\033\020\001\032\t\022\005\022\0030\0010%2\t\b\001\020\006\032\0030\001H'J\033\020\001\032\t\022\005\022\0030\0010W2\t\b\001\020\006\032\0030\001H'J#\020\001\032\b\022\004\022\0020\t0\0032\b\b\001\020\034\032\0020\r2\b\b\001\0202\032\0020\rH'J-\020\001\032\b\022\004\022\0020\0330%2\b\b\001\020&\032\0020\r2\b\b\001\020\f\032\0020\r2\b\b\001\020'\032\0020\rH'J#\020\001\032\b\022\004\022\0020\0330\0032\b\b\001\020\f\032\0020\r2\b\b\001\020)\032\0020\rH'J-\020\001\032\b\022\004\022\0020\0330\0032\b\b\001\020\034\032\0020\r2\b\b\001\020\035\032\0020\r2\b\b\001\0209\032\0020\rH'J\033\020\001\032\t\022\005\022\0030\0010%2\t\b\001\020\006\032\0030\001H'J#\020\001\032\b\022\004\022\0020n0\0032\b\b\001\020\034\032\0020\r2\b\b\001\0202\032\0020\rH'JI\020\001\032\032\022\005\022\0030\001\022\004\022\0020-0+j\t\022\005\022\0030\001`.2\b\b\001\020\034\032\0020\r2\b\b\001\020?\032\0020\r2\b\b\001\0202\032\0020\rH\001\000\006\003\020\001J/\020\001\032\b\022\004\022\0020\0330\0032\n\b\001\020\001\032\0030\0012\b\b\001\020\f\032\0020\r2\b\b\001\020)\032\0020\rH'J/\020\001\032\b\022\004\022\0020\0330\0032\n\b\001\020\001\032\0030\0012\b\b\001\020\f\032\0020\r2\b\b\001\020)\032\0020\rH'J9\020\001\032\b\022\004\022\0020\0330\0032\n\b\001\020\001\032\0030\0012\b\b\001\020\034\032\0020\r2\b\b\001\020\035\032\0020\r2\b\b\001\0209\032\0020\rH'J.\020\001\032\b\022\004\022\0020\t0\0032\t\b\001\020\001\032\0020}2\b\b\001\020&\032\0020\r2\b\b\001\020~\032\0020\rH'J\032\020\001\032\b\022\004\022\0020\t0\0032\t\b\001\020\006\032\0030\001H'J\032\020\001\032\b\022\004\022\0020\t0W2\t\b\001\020\006\032\0030\001H'J\031\020\001\032\b\022\004\022\0020\t0\0032\b\b\001\020\f\032\0020\rH'J@\020\001\032\032\022\005\022\0030\001\022\004\022\0020-0+j\t\022\005\022\0030\001`.2\t\b\001\020\006\032\0030\0012\b\b\001\020\034\032\0020\rH\001\000\006\003\020\001J6\020\001\032\032\022\005\022\0030\001\022\004\022\0020-0+j\t\022\005\022\0030\001`.2\t\b\001\020\006\032\0030\001H\001\000\006\003\020\001J8\020\001\032\b\022\004\022\0020\0330\0032\t\b\001\020\006\032\0030\0012\b\b\001\020&\032\0020\r2\b\b\001\020\f\032\0020\r2\b\b\001\020)\032\0020\rH'J-\020\001\032\b\022\004\022\0020\0330\0032\b\b\001\0207\032\002082\b\b\001\020\f\032\0020\r2\b\b\001\020\036\032\0020\037H'J-\020\001\032\b\022\004\022\002060\0032\b\b\001\0207\032\002082\b\b\001\020&\032\0020\r2\b\b\001\020\f\032\0020\rH'JT\020\001\032\032\022\005\022\0030\001\022\004\022\0020-0+j\t\022\005\022\0030\001`.2\b\b\001\020\034\032\0020\r2\b\b\001\020?\032\0020\r2\b\b\001\0202\032\0020\r2\t\b\001\020\006\032\0030\001H\001\000\006\003\020\001JT\020\001\032\032\022\005\022\0030\001\022\004\022\0020-0+j\t\022\005\022\0030\001`.2\b\b\001\020\034\032\0020\r2\b\b\001\020?\032\0020\r2\b\b\001\0202\032\0020\r2\t\b\001\020\006\032\0030\001H\001\000\006\003\020\001J-\020\001\032\b\022\004\022\0020\0330\0032\b\b\001\020\034\032\0020\r2\b\b\001\020\035\032\0020\r2\b\b\001\0209\032\0020\rH'J#\020\001\032\b\022\004\022\0020\0330\0032\b\b\001\020\f\032\0020\r2\b\b\001\020)\032\0020\rH'J#\020\001\032\b\022\004\022\0020\t0\0032\b\b\001\020\f\032\0020\r2\b\b\001\020)\032\0020\rH'J#\020\001\032\b\022\004\022\0020\t0\0032\b\b\001\020\f\032\0020\r2\b\b\001\020)\032\0020\rH'J#\020\001\032\b\022\004\022\0020\t0W2\b\b\001\020\035\032\0020\r2\b\b\001\020D\032\0020\rH'J0\020\001\032\b\022\004\022\0020\t0\0032\n\b\001\020\001\032\0030\0012\b\b\001\020\f\032\0020\r2\t\b\001\020\001\032\0020\rH'JA\020\001\032\032\022\005\022\0030\001\022\004\022\0020-0+j\t\022\005\022\0030\001`.2\n\b\001\020\001\032\0030\0012\b\b\001\020&\032\0020\rH\001\000\006\003\020\001J\033\020\001\032\b\022\004\022\0020\t0\0032\n\b\001\020\001\032\0030\001H'J\032\020\001\032\t\022\005\022\0030\0010\0032\b\b\001\020g\032\0020\037H'J>\020\001\032\030\022\004\022\0020,\022\004\022\0020-0+j\b\022\004\022\0020,`.2\b\b\001\0202\032\0020\r2\t\b\001\020\006\032\0030\001H\001\000\006\003\020\001J/\020\001\032\b\022\004\022\0020\t0\0032\n\b\001\020\001\032\0030\0012\b\b\001\020\f\032\0020\r2\b\b\001\020D\032\0020\rH'J/\020\001\032\b\022\004\022\0020\t0W2\n\b\001\020\001\032\0030\0012\b\b\001\020\f\032\0020\r2\b\b\001\020D\032\0020\rH'J%\020\001\032\b\022\004\022\0020\t0\0032\n\b\001\020\001\032\0030\0012\b\b\001\020\f\032\0020\rH'J/\020\002\032\b\022\004\022\0020\t0\0032\n\b\001\020\002\032\0030\0022\b\b\001\020\f\032\0020\r2\b\b\001\020H\032\0020\rH'J/\020\002\032\b\022\004\022\0020\t0\0032\n\b\001\020\002\032\0030\0022\b\b\001\020\f\032\0020\r2\b\b\001\020\016\032\0020\rH'J+\020\002\032\020\022\f\022\n\022\005\022\0030\0010\0010\0032\b\b\001\020\n\032\0020\0132\b\b\001\020\f\032\0020\rH'J%\020\002\032\b\022\004\022\0020\t0\0032\n\b\001\020\002\032\0030\0022\b\b\001\020\f\032\0020\rH'J%\020\002\032\b\022\004\022\0020\t0\0032\n\b\001\020\002\032\0030\0022\b\b\001\020\f\032\0020\rH'J@\020\002\032\032\022\005\022\0030\001\022\004\022\0020-0+j\t\022\005\022\0030\001`.2\t\b\001\020\006\032\0030\0012\b\b\001\020?\032\0020\rH\001\000\006\003\020\001J\033\020\002\032\t\022\005\022\0030\0020%2\t\b\001\020\006\032\0030\002H'J\033\020\002\032\t\022\005\022\0030\0020%2\t\b\001\020\006\032\0030\002H'J\031\020\002\032\b\022\004\022\0020n0\0032\b\b\001\020&\032\0020\rH'J#\020\002\032\b\022\004\022\0020n0\0032\b\b\001\020&\032\0020\r2\b\b\001\020~\032\0020\rH'J\031\020\002\032\b\022\004\022\0020n0\0032\b\b\001\020&\032\0020\rH'J&\020\002\032\t\022\005\022\0030\0020\0032\b\b\001\020&\032\0020\r2\n\b\001\020\002\032\0030\002H'J0\020\002\032\t\022\005\022\0030\0020\0032\b\b\001\020\034\032\0020\r2\b\b\001\0202\032\0020\r2\n\b\001\020\002\032\0030\002H'J0\020\002\032\t\022\005\022\0030\0020\0032\b\b\001\020&\032\0020\r2\b\b\001\020~\032\0020\r2\n\b\001\020\002\032\0030\002H'J0\020\002\032\t\022\005\022\0030\0020\0032\b\b\001\020\034\032\0020\r2\b\b\001\0202\032\0020\r2\n\b\001\020\002\032\0030\002H'J\034\020\002\032\t\022\005\022\0030\0020\0032\n\b\001\020\002\032\0030\002H'J\032\020\002\032\b\022\004\022\0020\0010\0032\t\b\001\020\006\032\0030\002H'\002\004\n\002\b\031\006\002"}, d2 = {"Lcom/immediasemi/blink/api/retrofit/BlinkWebService;", "", "accountOptions", "Lrx/Observable;", "Lcom/immediasemi/blink/models/AccountOptionsResponse;", "acknowledgeNotification", "body", "Lcom/immediasemi/blink/api/retrofit/AcknowledgeNotificationBody;", "activateSiren", "Lcom/immediasemi/blink/models/BlinkData;", "sirenDurationBody", "Lcom/immediasemi/blink/api/retrofit/SirenDurationBody;", "network", "", "siren", "activateSirens", "addCamera", "Lcom/immediasemi/blink/models/AddCameraResponseBody;", "addCameraBody", "Lcom/immediasemi/blink/api/retrofit/AddCameraBody;", "addSiren", "Lcom/immediasemi/blink/models/AddSirenResponse;", "addSirenNetworkBody", "Lcom/immediasemi/blink/api/retrofit/AddSirenNetworkBody;", "appUpdateStatus", "Lcom/immediasemi/blink/api/retrofit/UpdateStatusBody;", "armDisarmNetwork", "Lcom/immediasemi/blink/models/Command;", "accountId", "networkId", "type", "", "batteryUsage", "Lcom/immediasemi/blink/models/BatteryUsage;", "blinkStabilityStatus", "Lcom/immediasemi/blink/api/retrofit/StatusBoxBody;", "bulkDownloadClips", "Lrx/Single;", "account", "syncModuleId", "cameraMotion", "camera", "cancelTrial", "Lcom/github/michaelbull/result/Result;", "", "", "Lcom/immediasemi/blink/api/retrofit/NetworkResult;", "(JLkotlin/coroutines/Continuation;)Ljava/lang/Object;", "changeEmail", "Lcom/immediasemi/blink/api/retrofit/ChangeAccountDetailPinResponse;", "clientId", "changeEmailRequest", "Lcom/immediasemi/blink/api/retrofit/ChangeEmailRequest;", "changeOwlWifi", "Lcom/immediasemi/blink/api/retrofit/OwlAddBody;", "onboardingStartRequest", "Lcom/immediasemi/blink/api/retrofit/OnboardingStartRequest;", "owlId", "changePassword", "Lcom/immediasemi/blink/api/retrofit/TokenizedChangePassword;", "changePasswordUnauthenticated", "changePhoneNumber", "Lcom/immediasemi/blink/api/retrofit/ChangePhoneNumberResponse;", "userId", "Lcom/immediasemi/blink/api/retrofit/ChangePhoneNumberBody;", "(JJJLcom/immediasemi/blink/api/retrofit/ChangePhoneNumberBody;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "commandPolling", "Lcom/immediasemi/blink/models/Commands;", "commandId", "contactBlink", "Lcom/immediasemi/blink/api/retrofit/ContactBlink;", "createProgram", "program", "Lcom/immediasemi/blink/scheduling/Program;", "createSystem", "Lcom/immediasemi/blink/models/ANetwork;", "addNetworkBody", "Lcom/immediasemi/blink/api/retrofit/AddNetworkBody;", "deactivateSirens", "deleteAccount", "deleteAccountBody", "Lcom/immediasemi/blink/api/retrofit/DeleteAccountBody;", "deleteCamera", "deleteClip", "clipId", "manifestId", "deleteMediaCall", "Lretrofit2/Call;", "mediaIdList", "Lcom/immediasemi/blink/api/retrofit/MediaIdListBody;", "deleteOwl", "deleteProgram", "deleteSirens", "deleteSyncModule", "number", "deleteSystem", "disableProgram", "disableSyncModuleBackup", "downloadFirmware", "Lretrofit2/adapter/rxjava/Result;", "Lokhttp3/ResponseBody;", "url", "downloadFirmwareUpdate", "serial", "downloadOwlFirmwareUpdate", "ejectUsbStorage", "enableProgram", "enableSyncModuleBackup", "formatUsbStorage", "generateChangePasswordPinCode", "Lcom/immediasemi/blink/api/retrofit/SendPinResponse;", "generateChangePasswordPinCodeUnauthenticated", "request", "Lcom/immediasemi/blink/api/retrofit/ResetPasswordUnauthenticatedRequest;", "getAccount", "Lcom/immediasemi/blink/utils/sync/Account;", "getCameraConfig", "Lcom/immediasemi/blink/models/CameraConfig;", "getChangedMedia", "Lcom/immediasemi/blink/models/ChangedMedia;", "since", "Lorg/threeten/bp/OffsetDateTime;", "page", "", "getClientOptions", "Lcom/immediasemi/blink/utils/clientoption/ClientOptionsResponse;", "client", "getClipCommandId", "getClipListManifest", "Lcom/immediasemi/blink/api/retrofit/ClipsResponse;", "manifestCommandId", "getClipListManifestCommandId", "getCountries", "Lcom/immediasemi/blink/api/retrofit/CountriesResponse;", "(Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "getEntitlements", "Lcom/immediasemi/blink/api/retrofit/EntitlementResponse;", "getLocalStorageStatus", "Lcom/immediasemi/blink/api/retrofit/LocalStorageStatusResponse;", "getOwlConfig", "Lcom/immediasemi/blink/models/OwlConfigInfo;", "getPrograms", "", "getRegions", "Lcom/immediasemi/blink/models/QuickRegionInfo;", "country", "(Ljava/lang/String;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "getSirens", "", "Lcom/immediasemi/blink/models/Siren;", "getSirensForAllNetworks", "Lcom/immediasemi/blink/utils/SirensReponse;", "getSubscription", "Lcom/immediasemi/blink/api/retrofit/Subscription;", "subscriptionId", "(JJLkotlin/coroutines/Continuation;)Ljava/lang/Object;", "getSubscriptions", "Lcom/immediasemi/blink/api/retrofit/SubscriptionsResponse;", "getTrialInfo", "Lcom/immediasemi/blink/api/retrofit/SubscriptionTrialResponse;", "getZones", "Lcom/immediasemi/blink/api/retrofit/AdvancedCameraZones;", "homescreenV3", "Lcom/immediasemi/blink/utils/sync/HomescreenV3;", "identifyDevice", "Lcom/immediasemi/blink/api/retrofit/IdentifyDeviceResponse;", "serialNumber", "linkAmazonAccount", "Lcom/immediasemi/blink/utils/LinkUnLinkAmazonAccountResponse;", "mapLinkBody", "Lcom/immediasemi/blink/utils/MapLinkBody;", "(Lcom/immediasemi/blink/utils/MapLinkBody;JLkotlin/coroutines/Continuation;)Ljava/lang/Object;", "linkAmazonRequestStatus", "Lcom/immediasemi/blink/utils/SubscriptionPollingResponse;", "Lcom/immediasemi/blink/utils/VerifyAmazonLinkStatusBody;", "uuid", "(Lcom/immediasemi/blink/utils/VerifyAmazonLinkStatusBody;JLjava/lang/String;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "liveViewOwl", "Lcom/immediasemi/blink/api/retrofit/PirPollingResponse;", "Lcom/immediasemi/blink/api/retrofit/LiveViewBody;", "owl", "liveViewV5", "loadCameraStatus", "Lcom/immediasemi/blink/models/SignalStrength;", "login", "Lcom/immediasemi/blink/api/retrofit/AuthenticationResponse;", "Lcom/immediasemi/blink/api/retrofit/LoginBody;", "loginCall", "logout", "mountUsb", "refreshCameraStatus", "refreshOwlStatus", "register", "Lcom/immediasemi/blink/api/retrofit/RegisterBody;", "resendChangeEmailPinCode", "resendClientVerificationCode", "Lcom/immediasemi/blink/api/retrofit/ResendClientVerificationCodeResponse;", "(JJJLkotlin/coroutines/Continuation;)Ljava/lang/Object;", "saveCalibrateTemperature", "calibrate", "Lcom/immediasemi/blink/api/retrofit/Calibrate;", "saveCameraSettings", "updateCameraBody", "Lcom/immediasemi/blink/api/retrofit/UpdateCameraBody;", "saveOwlSettings", "updateOwlBody", "Lcom/immediasemi/blink/models/UpdateOwlBody;", "sendClientOptions", "clientOptions", "sendLogs", "Lcom/immediasemi/blink/api/retrofit/LogsBody;", "sendLogsCall", "sendSystemOfflineHelpEmaail", "setAccountCountry", "Lcom/immediasemi/blink/api/retrofit/CountryResponse;", "Lcom/immediasemi/blink/api/retrofit/CountryBody;", "(Lcom/immediasemi/blink/api/retrofit/CountryBody;JLkotlin/coroutines/Continuation;)Ljava/lang/Object;", "setTivLock", "Lcom/immediasemi/blink/api/retrofit/SetTivLockResponse;", "Lcom/immediasemi/blink/api/retrofit/TivLockBody;", "(Lcom/immediasemi/blink/api/retrofit/TivLockBody;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "setZones", "startOnboarding", "startOwlOnboarding", "submitClientVerificationCode", "Lcom/immediasemi/blink/api/retrofit/SubmitVerificationResponse;", "Lcom/immediasemi/blink/api/retrofit/SubmitVerificationRequest;", "(JJJLcom/immediasemi/blink/api/retrofit/SubmitVerificationRequest;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "submitPhoneNumberVerificationCode", "takeOwlThumbnail", "takeThumbnail", "tempAlertDisable", "tempAlertEnable", "terminateCommand", "terminateOnboardingCommand", "terminateOnboardingBody", "Lcom/immediasemi/blink/api/retrofit/TerminateOnboardingBody;", "command", "unlinkAmazonAccount", "verifyLinkAccountBody", "Lcom/immediasemi/blink/utils/VerifyLinkAccountBody;", "(Lcom/immediasemi/blink/utils/VerifyLinkAccountBody;JLkotlin/coroutines/Continuation;)Ljava/lang/Object;", "updateAccount", "updateAccountBody", "Lcom/immediasemi/blink/api/retrofit/UpdateAccountBody;", "updateCheck", "Lcom/immediasemi/blink/api/retrofit/UpdateCheckBodyReceiveBody;", "updateClient", "Lcom/immediasemi/blink/api/retrofit/UpdateClientBody;", "(JLcom/immediasemi/blink/api/retrofit/UpdateClientBody;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "updateCommand", "updateCommandRequest", "Lcom/immediasemi/blink/api/requests/onboarding/OnboardingCommandUpdate/UpdateCommandRequest;", "updateCommandSync", "updateNetworkSaveAllLiveViews", "Lcom/immediasemi/blink/api/retrofit/UpdateNetworkSaveAllLiveViews;", "updateProgram", "updateProgramRequest", "Lcom/immediasemi/blink/scheduling/UpdateProgramRequest;", "updateSiren", "sirenNameBody", "Lcom/immediasemi/blink/api/retrofit/SirenNameBody;", "updateSirens", "updateSystem", "updateSystemNameBody", "Lcom/immediasemi/blink/api/retrofit/UpdateSystemNameBody;", "updateTimezone", "updateTimezoneBody", "Lcom/immediasemi/blink/api/retrofit/UpdateTimezoneBody;", "updateUserCountry", "validateEmailAddress", "Lcom/immediasemi/blink/createaccount/ValidationResponse;", "Lcom/immediasemi/blink/createaccount/ValidateEmailBody;", "validatePassword", "Lcom/immediasemi/blink/createaccount/ValidatePasswordBody;", "verificationEmail", "verificationPinClient", "verificationPinEmail", "verifyAccountPIN", "Lcom/immediasemi/blink/api/retrofit/PinVerificationResponse;", "verifyPinBody", "Lcom/immediasemi/blink/api/retrofit/VerifyPinBody;", "verifyChangeEmailPinCode", "verifyClientPIN", "verifyPasswordChangePinCode", "verifyPasswordChangePinCodeUnauthenticated", "videoOptionsSetter", "Lcom/immediasemi/blink/utils/AutoPurgeSetterBody;", "Companion", "app_prodRelease"}, k = 1, mv = {1, 4, 2})
    public interface BlinkWebService {
        public static final Companion Companion = Companion.$$INSTANCE;
  
        public static final String HTTP_APP_BUILD = "APP-BUILD";
  
        public static final String LOCALE = "LOCALE";
  
        public static final String TOKEN_AUTH_HEADER = "TOKEN-AUTH";
  
        @GET("https://rest-{tier}.immedia-semi.com/api/v1/account/options")
        Observable<AccountOptionsResponse> accountOptions();
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v2/notification")
        Observable<Object> acknowledgeNotification(@Body AcknowledgeNotificationBody paramAcknowledgeNotificationBody);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/networks/{network}/sirens/{siren}/activate/")
        Observable<BlinkData> activateSiren(@Body SirenDurationBody paramSirenDurationBody, @Path("network") long paramLong1, @Path("siren") long paramLong2);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/networks/{network}/sirens/activate/")
        Observable<BlinkData> activateSirens(@Path("network") long paramLong);
  
        @POST("https://rest-{tier}.immedia-semi.com/network/{network}/camera/add")
        Observable<AddCameraResponseBody> addCamera(@Body AddCameraBody paramAddCameraBody, @Path("network") long paramLong);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/networks/{network}/sirens/add/")
        Observable<AddSirenResponse> addSiren(@Body AddSirenNetworkBody paramAddSirenNetworkBody, @Path("network") long paramLong);
  
        @GET("https://rest-{tier}.immedia-semi.com/api/v1/version")
        Observable<UpdateStatusBody> appUpdateStatus();
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{accountId}/networks/{networkId}/state/{type}")
        Observable<Command> armDisarmNetwork(@Path("accountId") long paramLong1, @Path("networkId") long paramLong2, @Path("type") String paramString);
  
        @GET("https://rest-{tier}.immedia-semi.com/api/v1/camera/usage")
        Observable<BatteryUsage> batteryUsage();
  
        @GET("https://blinkstatus.net/api/v1/{tier}")
        Observable<StatusBoxBody> blinkStabilityStatus();
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account_id}/networks/{network}/sync_modules/{sync_module_id}/local_storage/bulk_download")
        Single<Command> bulkDownloadClips(@Path("account_id") long paramLong1, @Path("network") long paramLong2, @Path("sync_module_id") long paramLong3);
  
        @POST("https://rest-{tier}.immedia-semi.com/network/{network}/camera/{camera}/{type}")
        Observable<Command> cameraMotion(@Path("network") long paramLong1, @Path("camera") long paramLong2, @Path("type") String paramString);
  
        @DELETE("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account_id}/subscriptions/plans/cancel_trial/")
        Object cancelTrial(@Path("account_id") long paramLong, Continuation<? super Result<Unit, ? extends Throwable>> paramContinuation);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/{accountId}/client/{clientId}/email_change/")
        Observable<ChangeAccountDetailPinResponse> changeEmail(@Path("accountId") long paramLong1, @Path("clientId") long paramLong2, @Body ChangeEmailRequest paramChangeEmailRequest);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{accountId}/networks/{networkId}/owls/{owlId}/change_wifi")
        Observable<OwlAddBody> changeOwlWifi(@Body OnboardingStartRequest paramOnboardingStartRequest, @Path("accountId") long paramLong1, @Path("networkId") long paramLong2, @Path("owlId") long paramLong3);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/{accountId}/client/{clientId}/password_change/")
        Observable<BlinkData> changePassword(@Path("accountId") long paramLong1, @Path("clientId") long paramLong2, @Body TokenizedChangePassword paramTokenizedChangePassword);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/password_change/")
        Observable<BlinkData> changePasswordUnauthenticated(@Body TokenizedChangePassword paramTokenizedChangePassword);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v5/accounts/{account_id}/users/{user_id}/clients/{client_id}/phone_number_change/")
        Object changePhoneNumber(@Path("account_id") long paramLong1, @Path("user_id") long paramLong2, @Path("client_id") long paramLong3, @Body ChangePhoneNumberBody paramChangePhoneNumberBody, Continuation<? super Result<ChangePhoneNumberResponse, ? extends Throwable>> paramContinuation);
  
        @GET("https://rest-{tier}.immedia-semi.com/network/{network}/command/{command}")
        Observable<Commands> commandPolling(@Path("network") long paramLong1, @Path("command") long paramLong2);
  
        @GET("https://rest-{tier}.immedia-semi.com/api/v2/support/ob_phone/")
        Observable<ContactBlink> contactBlink();
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/networks/{network}/programs/create")
        Observable<BlinkData> createProgram(@Body Program paramProgram, @Path("network") long paramLong);
  
        @POST("https://rest-{tier}.immedia-semi.com/network/add")
        Observable<ANetwork> createSystem(@Body AddNetworkBody paramAddNetworkBody);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/networks/{network}/sirens/deactivate/")
        Observable<BlinkData> deactivateSirens(@Path("network") long paramLong);
  
        @POST("https://rest-{tier}.immedia-semi.com/account/delete/")
        Observable<BlinkData> deleteAccount(@Body DeleteAccountBody paramDeleteAccountBody);
  
        @POST("https://rest-{tier}.immedia-semi.com/network/{network}/camera/{camera}/delete/")
        Observable<BlinkData> deleteCamera(@Path("network") long paramLong1, @Path("camera") long paramLong2);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account_id}/networks/{network}/sync_modules/{sync_module_id}/local_storage/manifest/{manifest_id}/clip/delete/{clip_id}")
        Single<Command> deleteClip(@Path("account_id") long paramLong1, @Path("network") long paramLong2, @Path("sync_module_id") long paramLong3, @Path("clip_id") long paramLong4, @Path("manifest_id") long paramLong5);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{accountId}/media/delete")
        Call<Object> deleteMediaCall(@Body MediaIdListBody paramMediaIdListBody, @Path("accountId") long paramLong);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{accountId}/networks/{networkId}/owls/{owlId}/delete")
        Observable<BlinkData> deleteOwl(@Path("accountId") long paramLong1, @Path("networkId") long paramLong2, @Path("owlId") long paramLong3);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/networks/{network}/programs/{program}/delete")
        Observable<BlinkData> deleteProgram(@Path("network") long paramLong1, @Path("program") long paramLong2);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/networks/{network}/sirens/{siren}/delete")
        Observable<BlinkData> deleteSirens(@Path("network") long paramLong1, @Path("siren") long paramLong2);
  
        @POST("https://rest-{tier}.immedia-semi.com/network/{network}/syncmodule/{syncmodule}/delete/")
        Observable<BlinkData> deleteSyncModule(@Path("network") long paramLong, @Path("syncmodule") String paramString);
  
        @POST("https://rest-{tier}.immedia-semi.com/network/{network}/delete")
        Observable<BlinkData> deleteSystem(@Path("network") long paramLong);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/networks/{network}/programs/{program}/disable")
        Observable<BlinkData> disableProgram(@Path("network") long paramLong1, @Path("program") long paramLong2);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account_id}/networks/{network}/sync_modules/{sync_module_id}/local_storage/sm_backup/disable")
        Single<BlinkData> disableSyncModuleBackup(@Path("account_id") long paramLong1, @Path("network") long paramLong2, @Path("sync_module_id") long paramLong3);
  
        @GET
        Observable<Result<ResponseBody>> downloadFirmware(@Url String paramString);
  
        @GET("https://rest-{tier}.immedia-semi.com/api/v1/sync_modules/{serial}/fw_update")
        Observable<Result<ResponseBody>> downloadFirmwareUpdate(@Path("serial") String paramString);
  
        @GET("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{accountId}/owls/{serial}/fw_update")
        Observable<Result<ResponseBody>> downloadOwlFirmwareUpdate(@Path("accountId") long paramLong, @Path("serial") String paramString);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account_id}/networks/{network}/sync_modules/{sync_module_id}/local_storage/eject")
        Single<Command> ejectUsbStorage(@Path("account_id") long paramLong1, @Path("network") long paramLong2, @Path("sync_module_id") long paramLong3);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/networks/{network}/programs/{program}/enable")
        Observable<BlinkData> enableProgram(@Path("network") long paramLong1, @Path("program") long paramLong2);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account_id}/networks/{network}/sync_modules/{sync_module_id}/local_storage/sm_backup/enable")
        Single<BlinkData> enableSyncModuleBackup(@Path("account_id") long paramLong1, @Path("network") long paramLong2, @Path("sync_module_id") long paramLong3);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account_id}/networks/{network}/sync_modules/{sync_module_id}/local_storage/format")
        Single<Command> formatUsbStorage(@Path("account_id") long paramLong1, @Path("network") long paramLong2, @Path("sync_module_id") long paramLong3);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/{accountId}/client/{clientId}/password_change/pin/generate/")
        Observable<SendPinResponse> generateChangePasswordPinCode(@Path("accountId") long paramLong1, @Path("clientId") long paramLong2);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/password_change/pin/generate/")
        Observable<SendPinResponse> generateChangePasswordPinCodeUnauthenticated(@Body ResetPasswordUnauthenticatedRequest paramResetPasswordUnauthenticatedRequest);
  
        @GET("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account_id}/info/")
        Object getAccount(@Path("account_id") long paramLong, Continuation<? super Result<Account, ? extends Throwable>> paramContinuation);
  
        @GET("https://rest-{tier}.immedia-semi.com/network/{network}/camera/{camera}/config")
        Observable<CameraConfig> getCameraConfig(@Path("network") long paramLong1, @Path("camera") long paramLong2);
  
        @GET("https://rest-{tier}.immedia-semi.com/api/v2/accounts/{accountId}/media/changed")
        Call<ChangedMedia> getChangedMedia(@Path("accountId") long paramLong, @Query("since") OffsetDateTime paramOffsetDateTime, @Query("page") int paramInt);
  
        @GET("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account}/clients/{client}/options")
        Observable<ClientOptionsResponse> getClientOptions(@Path("account") long paramLong1, @Path("client") long paramLong2);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account_id}/networks/{network}/sync_modules/{sync_module_id}/local_storage/manifest/{manifest_id}/clip/request/{clip_id}")
        Single<Command> getClipCommandId(@Path("account_id") long paramLong1, @Path("network") long paramLong2, @Path("sync_module_id") long paramLong3, @Path("clip_id") long paramLong4, @Path("manifest_id") long paramLong5);
  
        @GET("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account_id}/networks/{network}/sync_modules/{sync_module_id}/local_storage/manifest/request/{command}")
        Single<ClipsResponse> getClipListManifest(@Path("account_id") long paramLong1, @Path("network") long paramLong2, @Path("sync_module_id") long paramLong3, @Path("command") long paramLong4);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account_id}/networks/{network}/sync_modules/{sync_module_id}/local_storage/manifest/request")
        Single<Command> getClipListManifestCommandId(@Path("account_id") long paramLong1, @Path("network") long paramLong2, @Path("sync_module_id") long paramLong3);
  
        @GET("https://rest-{tier}.immedia-semi.com/api/v1/countries/")
        Object getCountries(Continuation<? super Result<CountriesResponse, ? extends Throwable>> paramContinuation);
  
        @GET("https://rest-{tier}.immedia-semi.com/api/v2/accounts/{account}/subscriptions/entitlements")
        Object getEntitlements(@Path("account") long paramLong, Continuation<? super Result<EntitlementResponse, ? extends Throwable>> paramContinuation);
  
        @GET("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account_id}/networks/{network}/sync_modules/{sync_module_id}/local_storage/status")
        Single<LocalStorageStatusResponse> getLocalStorageStatus(@Path("account_id") long paramLong1, @Path("network") long paramLong2, @Path("sync_module_id") long paramLong3);
  
        @GET("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{accountId}/networks/{networkId}/owls/{owlId}/config")
        Observable<OwlConfigInfo> getOwlConfig(@Path("accountId") long paramLong1, @Path("networkId") long paramLong2, @Path("owlId") long paramLong3);
  
        @GET("https://rest-{tier}.immedia-semi.com/api/v1/networks/{network}/programs")
        Observable<List<Program>> getPrograms(@Path("network") long paramLong);
  
        @GET("https://rest-{tier}.immedia-semi.com/regions")
        Object getRegions(@Query("country") String paramString, Continuation<? super Result<? extends QuickRegionInfo, ? extends Throwable>> paramContinuation);
  
        @GET("https://rest-{tier}.immedia-semi.com/api/v1/networks/{network}/sirens/")
        Observable<Siren[]> getSirens(@Path("network") long paramLong);
  
        @GET("https://rest-{tier}.immedia-semi.com/api/v1/sirens/")
        Observable<SirensReponse> getSirensForAllNetworks();
  
        @GET("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account}/subscriptions/plans/{subscription}")
        Object getSubscription(@Path("account") long paramLong1, @Path("subscription") long paramLong2, Continuation<? super Result<Subscription, ? extends Throwable>> paramContinuation);
  
        @GET("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account}/subscriptions/plans")
        Object getSubscriptions(@Path("account") long paramLong, Continuation<? super Result<SubscriptionsResponse, ? extends Throwable>> paramContinuation);
  
        @GET("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{accountId}/commands/{commandId}/result")
        Object getTrialInfo(@Path("accountId") long paramLong1, @Path("commandId") long paramLong2, Continuation<? super Result<SubscriptionTrialResponse, ? extends Throwable>> paramContinuation);
  
        @GET("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account}/networks/{network}/cameras/{camera}/zones")
        Observable<AdvancedCameraZones> getZones(@Path("account") long paramLong1, @Path("network") long paramLong2, @Path("camera") long paramLong3);
  
        @GET("https://rest-{tier}.immedia-semi.com/api/v3/accounts/{account}/homescreen")
        Single<HomescreenV3> homescreenV3(@Path("account") long paramLong);
  
        @GET("https://rest-{tier}.immedia-semi.com/api/v2/devices/identify/{serialNumber}")
        Single<IdentifyDeviceResponse> identifyDevice(@Path("serialNumber") String paramString);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account}/subscriptions/link/link_account")
        Object linkAmazonAccount(@Body MapLinkBody paramMapLinkBody, @Path("account") long paramLong, Continuation<? super Result<LinkUnLinkAmazonAccountResponse, ? extends Throwable>> paramContinuation);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account}/subscriptions/request/status/{uuid}")
        Object linkAmazonRequestStatus(@Body VerifyAmazonLinkStatusBody paramVerifyAmazonLinkStatusBody, @Path("account") long paramLong, @Path("uuid") String paramString, Continuation<? super Result<SubscriptionPollingResponse, ? extends Throwable>> paramContinuation);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account}/networks/{network}/owls/{owl}/liveview")
        Observable<PirPollingResponse> liveViewOwl(@Body LiveViewBody paramLiveViewBody, @Path("account") long paramLong1, @Path("network") long paramLong2, @Path("owl") long paramLong3);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v5/accounts/{account}/networks/{network}/cameras/{camera}/liveview")
        Observable<PirPollingResponse> liveViewV5(@Body LiveViewBody paramLiveViewBody, @Path("account") long paramLong1, @Path("network") long paramLong2, @Path("camera") long paramLong3);
  
        @GET("https://rest-{tier}.immedia-semi.com/network/{network}/camera/{camera}/signals")
        Observable<SignalStrength> loadCameraStatus(@Path("network") long paramLong1, @Path("camera") long paramLong2);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v5/account/login")
        Single<AuthenticationResponse> login(@Body LoginBody paramLoginBody);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v5/account/login")
        Call<AuthenticationResponse> loginCall(@Body LoginBody paramLoginBody);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/{accountId}/client/{clientId}/logout/")
        Observable<BlinkData> logout(@Path("accountId") long paramLong1, @Path("clientId") long paramLong2);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account_id}/networks/{network}/sync_modules/{sync_module_id}/local_storage/mount")
        Single<Command> mountUsb(@Path("account_id") long paramLong1, @Path("network") long paramLong2, @Path("sync_module_id") long paramLong3);
  
        @POST("https://rest-{tier}.immedia-semi.com/network/{network}/camera/{camera}/status")
        Observable<Command> refreshCameraStatus(@Path("network") long paramLong1, @Path("camera") long paramLong2);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{accountId}/networks/{networkId}/owls/{owlId}/status")
        Observable<Command> refreshOwlStatus(@Path("accountId") long paramLong1, @Path("networkId") long paramLong2, @Path("owlId") long paramLong3);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v6/account/register")
        Single<AuthenticationResponse> register(@Body RegisterBody paramRegisterBody);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/{accountId}/client/{clientId}/email_change/pin/resend")
        Observable<SendPinResponse> resendChangeEmailPinCode(@Path("accountId") long paramLong1, @Path("clientId") long paramLong2);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v5/accounts/{account_id}/users/{user_id}/clients/{client_id}/client_verification/pin/resend/")
        Object resendClientVerificationCode(@Path("account_id") long paramLong1, @Path("user_id") long paramLong2, @Path("client_id") long paramLong3, Continuation<? super Result<ResendClientVerificationCodeResponse, ? extends Throwable>> paramContinuation);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/network/{network}/camera/{camera}/calibrate")
        Observable<Command> saveCalibrateTemperature(@Body Calibrate paramCalibrate, @Path("network") long paramLong1, @Path("camera") long paramLong2);
  
        @POST("https://rest-{tier}.immedia-semi.com/network/{network}/camera/{camera}/update")
        Observable<Command> saveCameraSettings(@Body UpdateCameraBody paramUpdateCameraBody, @Path("network") long paramLong1, @Path("camera") long paramLong2);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{accountId}/networks/{networkId}/owls/{owlId}/config")
        Observable<Command> saveOwlSettings(@Body UpdateOwlBody paramUpdateOwlBody, @Path("accountId") long paramLong1, @Path("networkId") long paramLong2, @Path("owlId") long paramLong3);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account}/clients/{client}/options")
        Observable<BlinkData> sendClientOptions(@Body ClientOptionsResponse paramClientOptionsResponse, @Path("account") long paramLong1, @Path("client") long paramLong2);
  
        @POST("https://rest-{tier}.immedia-semi.com/app/logs/upload/")
        Observable<BlinkData> sendLogs(@Body LogsBody paramLogsBody);
  
        @POST("https://rest-{tier}.immedia-semi.com/app/logs/upload/")
        Call<BlinkData> sendLogsCall(@Body LogsBody paramLogsBody);
  
        @POST("https://rest-{tier}.immedia-semi.com/account/system_offline/{network}")
        Observable<BlinkData> sendSystemOfflineHelpEmaail(@Path("network") long paramLong);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account_id}/country/update/")
        Object setAccountCountry(@Body CountryBody paramCountryBody, @Path("account_id") long paramLong, Continuation<? super Result<CountryResponse, ? extends Throwable>> paramContinuation);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/account/tiv")
        Object setTivLock(@Body TivLockBody paramTivLockBody, Continuation<? super Result<SetTivLockResponse, ? extends Throwable>> paramContinuation);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account}/networks/{network}/cameras/{camera}/zones")
        Observable<Command> setZones(@Body AdvancedCameraZones paramAdvancedCameraZones, @Path("account") long paramLong1, @Path("network") long paramLong2, @Path("camera") long paramLong3);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v2/network/{network}/sync_module/{type}")
        Observable<Command> startOnboarding(@Body OnboardingStartRequest paramOnboardingStartRequest, @Path("network") long paramLong, @Path("type") String paramString);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account}/networks/{network}/owls/add")
        Observable<OwlAddBody> startOwlOnboarding(@Body OnboardingStartRequest paramOnboardingStartRequest, @Path("account") long paramLong1, @Path("network") long paramLong2);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v5/accounts/{account_id}/users/{user_id}/clients/{client_id}/client_verification/pin/verify/")
        Object submitClientVerificationCode(@Path("account_id") long paramLong1, @Path("user_id") long paramLong2, @Path("client_id") long paramLong3, @Body SubmitVerificationRequest paramSubmitVerificationRequest, Continuation<? super Result<SubmitVerificationResponse, ? extends Throwable>> paramContinuation);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v5/accounts/{account_id}/users/{user_id}/clients/{client_id}/phone_number_change/pin/verify")
        Object submitPhoneNumberVerificationCode(@Path("account_id") long paramLong1, @Path("user_id") long paramLong2, @Path("client_id") long paramLong3, @Body SubmitVerificationRequest paramSubmitVerificationRequest, Continuation<? super Result<SubmitVerificationResponse, ? extends Throwable>> paramContinuation);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{accountId}/networks/{networkId}/owls/{owlId}/thumbnail")
        Observable<Command> takeOwlThumbnail(@Path("accountId") long paramLong1, @Path("networkId") long paramLong2, @Path("owlId") long paramLong3);
  
        @POST("https://rest-{tier}.immedia-semi.com/network/{network}/camera/{camera}/thumbnail")
        Observable<Command> takeThumbnail(@Path("network") long paramLong1, @Path("camera") long paramLong2);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/network/{network}/camera/{camera}/temp_alert_disable")
        Observable<BlinkData> tempAlertDisable(@Path("network") long paramLong1, @Path("camera") long paramLong2);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/network/{network}/camera/{camera}/temp_alert_enable")
        Observable<BlinkData> tempAlertEnable(@Path("network") long paramLong1, @Path("camera") long paramLong2);
  
        @POST("https://rest-{tier}.immedia-semi.com/network/{network}/command/{command}/done/")
        Call<BlinkData> terminateCommand(@Path("network") long paramLong1, @Path("command") long paramLong2);
  
        @POST("https://rest-{tier}.immedia-semi.com/network/{network}/command/{command}/update/")
        Observable<BlinkData> terminateOnboardingCommand(@Body TerminateOnboardingBody paramTerminateOnboardingBody, @Path("network") long paramLong1, @Path("command") long paramLong2);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account}/subscriptions/link/unlink_account")
        Object unlinkAmazonAccount(@Body VerifyLinkAccountBody paramVerifyLinkAccountBody, @Path("account") long paramLong, Continuation<? super Result<LinkUnLinkAmazonAccountResponse, ? extends Throwable>> paramContinuation);
  
        @POST("https://rest-{tier}.immedia-semi.com/account/update")
        Observable<BlinkData> updateAccount(@Body UpdateAccountBody paramUpdateAccountBody);
  
        @GET("https://rest-{tier}.immedia-semi.com/api/v1/fw/app/update_check")
        Observable<UpdateCheckBodyReceiveBody> updateCheck(@Query("serial") String paramString);
  
        @POST("https://rest-{tier}.immedia-semi.com/client/{client_id}/update")
        Object updateClient(@Path("client_id") long paramLong, @Body UpdateClientBody paramUpdateClientBody, Continuation<? super Result<Unit, ? extends Throwable>> paramContinuation);
  
        @POST("https://rest-{tier}.immedia-semi.com/network/{network}/command/{command}/update/")
        Observable<BlinkData> updateCommand(@Body UpdateCommandRequest paramUpdateCommandRequest, @Path("network") long paramLong1, @Path("command") long paramLong2);
  
        @POST("https://rest-{tier}.immedia-semi.com/network/{network}/command/{command}/update/")
        Call<BlinkData> updateCommandSync(@Body UpdateCommandRequest paramUpdateCommandRequest, @Path("network") long paramLong1, @Path("command") long paramLong2);
  
        @POST("https://rest-{tier}.immedia-semi.com/network/{network}/update")
        Observable<BlinkData> updateNetworkSaveAllLiveViews(@Body UpdateNetworkSaveAllLiveViews paramUpdateNetworkSaveAllLiveViews, @Path("network") long paramLong);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/networks/{network}/programs/{program}/update")
        Observable<BlinkData> updateProgram(@Body UpdateProgramRequest paramUpdateProgramRequest, @Path("network") long paramLong1, @Path("program") long paramLong2);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/networks/{network}/sirens/{siren}/update")
        Observable<BlinkData> updateSiren(@Body SirenNameBody paramSirenNameBody, @Path("network") long paramLong1, @Path("siren") long paramLong2);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/networks/{network}/sirens/update")
        Observable<Siren[]> updateSirens(@Body SirenDurationBody paramSirenDurationBody, @Path("network") long paramLong);
  
        @POST("https://rest-{tier}.immedia-semi.com/network/{network}/update")
        Observable<BlinkData> updateSystem(@Body UpdateSystemNameBody paramUpdateSystemNameBody, @Path("network") long paramLong);
  
        @POST("https://rest-{tier}.immedia-semi.com/network/{network}/update")
        Observable<BlinkData> updateTimezone(@Body UpdateTimezoneBody paramUpdateTimezoneBody, @Path("network") long paramLong);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/users/{user_id}/country/update/")
        Object updateUserCountry(@Body CountryBody paramCountryBody, @Path("user_id") long paramLong, Continuation<? super Result<CountryResponse, ? extends Throwable>> paramContinuation);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v3/account/validate_email")
        Single<ValidationResponse> validateEmailAddress(@Body ValidateEmailBody paramValidateEmailBody);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v3/account/validate_password")
        Single<ValidationResponse> validatePassword(@Body ValidatePasswordBody paramValidatePasswordBody);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v3/account/{account}/resend_account_verification/")
        Observable<SendPinResponse> verificationEmail(@Path("account") long paramLong);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/{account}/client/{client}/pin/resend/")
        Observable<SendPinResponse> verificationPinClient(@Path("account") long paramLong1, @Path("client") long paramLong2);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/{account}/pin/resend/")
        Observable<SendPinResponse> verificationPinEmail(@Path("account") long paramLong);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/{account}/pin/verify/")
        Observable<PinVerificationResponse> verifyAccountPIN(@Path("account") long paramLong, @Body VerifyPinBody paramVerifyPinBody);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/{accountId}/client/{clientId}/email_change/pin/verify/")
        Observable<PinVerificationResponse> verifyChangeEmailPinCode(@Path("accountId") long paramLong1, @Path("clientId") long paramLong2, @Body VerifyPinBody paramVerifyPinBody);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/{account}/client/{client}/pin/verify/")
        Observable<PinVerificationResponse> verifyClientPIN(@Path("account") long paramLong1, @Path("client") long paramLong2, @Body VerifyPinBody paramVerifyPinBody);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/{accountId}/client/{clientId}/password_change/pin/verify/")
        Observable<PinVerificationResponse> verifyPasswordChangePinCode(@Path("accountId") long paramLong1, @Path("clientId") long paramLong2, @Body VerifyPinBody paramVerifyPinBody);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/password_change/pin/verify/")
        Observable<PinVerificationResponse> verifyPasswordChangePinCodeUnauthenticated(@Body VerifyPinBody paramVerifyPinBody);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/account/video_options")
        Observable<Object> videoOptionsSetter(@Body AutoPurgeSetterBody paramAutoPurgeSetterBody);
  
        @Metadata(bv = {1, 0, 3}, d1 = {"\000\024\n\002\030\002\n\002\020\000\n\002\b\002\n\002\020\016\n\002\b\003\b\003\030\0002\0020\001B\007\b\002\006\002\020\002R\016\020\003\032\0020\004X\006\002\n\000R\016\020\005\032\0020\004X\006\002\n\000R\016\020\006\032\0020\004X\006\002\n\000\006\007"}, d2 = {"Lcom/immediasemi/blink/api/retrofit/BlinkWebService$Companion;", "", "()V", "HTTP_APP_BUILD", "", "LOCALE", "TOKEN_AUTH_HEADER", "app_prodRelease"}, k = 1, mv = {1, 4, 2})
        public static final class Companion {
            static final Companion $$INSTANCE = new Companion();
    
            public static final String HTTP_APP_BUILD = "APP-BUILD";
    
            public static final String LOCALE = "LOCALE";
    
            public static final String TOKEN_AUTH_HEADER = "TOKEN-AUTH";
        }
    }
    */
    }
}
