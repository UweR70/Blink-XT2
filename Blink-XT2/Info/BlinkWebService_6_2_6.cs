namespace Info
{
    class BlinkWebService_6_2_6
    {

        /*  - This class does not have ANY code.
         *    It is added for documentation purpose only.
         *      
         *   - The below shown code 
         *     1) is the ORIGINAL code from the 
         *          Blink application
         *          App version 6.2.6 (published January, 14th 2021)
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

        import com.immediasemi.blink.api.requests.onboarding.OnboardingCommandUpdate.UpdateCommandRequest;
        import com.immediasemi.blink.createaccount.ValidateEmailBody;
        import com.immediasemi.blink.createaccount.ValidatePasswordBody;
        import com.immediasemi.blink.createaccount.ValidationResponse;
        import com.immediasemi.blink.models.ANetwork;
        import com.immediasemi.blink.models.AccountOptionsResponse;
        import com.immediasemi.blink.models.AccountRetrievalResponse;
        import com.immediasemi.blink.models.AddCameraResponseBody;
        import com.immediasemi.blink.models.AddSirenResponse;
        import com.immediasemi.blink.models.BatteryUsage;
        import com.immediasemi.blink.models.BlinkData;
        import com.immediasemi.blink.models.CameraConfig;
        import com.immediasemi.blink.models.CameraStatus;
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
        import com.immediasemi.blink.utils.SirensReponse;
        import com.immediasemi.blink.utils.clientoption.ClientOptionsResponse;
        import com.immediasemi.blink.utils.sync.HomescreenV3;
        import java.util.List;
        import kotlin.Metadata;
        import kotlin.coroutines.Continuation;
        import okhttp3.ResponseBody;
        import org.threeten.bp.OffsetDateTime;
        import retrofit2.Call;
        import retrofit2.Response;
        import retrofit2.adapter.rxjava.Result;
        import retrofit2.http.Body;
        import retrofit2.http.GET;
        import retrofit2.http.POST;
        import retrofit2.http.Path;
        import retrofit2.http.Query;
        import retrofit2.http.Url;
        import rx.Observable;
        import rx.Single;

        @Metadata(bv = {1, 0, 3}, d1 = {"\000\004\n\002\030\002\n\002\020\000\n\000\n\002\030\002\n\002\030\002\n\000\n\002\020\016\n\002\b\002\n\002\030\002\n\000\n\002\030\002\n\000\n\002\030\002\n\000\n\002\020\t\n\002\b\003\n\002\030\002\n\000\n\002\030\002\n\000\n\002\030\002\n\000\n\002\030\002\n\000\n\002\030\002\n\000\n\002\030\002\n\002\b\004\n\002\030\002\n\000\n\002\030\002\n\000\n\002\030\002\n\002\b\003\n\002\030\002\n\002\b\003\n\002\030\002\n\002\b\002\n\002\030\002\n\000\n\002\030\002\n\000\n\002\030\002\n\002\b\002\n\002\030\002\n\002\b\002\n\002\030\002\n\002\030\002\n\000\n\002\030\002\n\002\b\002\n\002\030\002\n\002\b\002\n\002\030\002\n\002\b\002\n\002\030\002\n\000\n\002\030\002\n\000\n\002\030\002\n\002\b\003\n\002\030\002\n\002\b\005\n\002\030\002\n\000\n\002\030\002\n\002\b\n\n\002\030\002\n\002\030\002\n\002\b\013\n\002\030\002\n\002\b\002\n\002\030\002\n\000\n\002\030\002\n\000\n\002\030\002\n\000\n\002\030\002\n\000\n\002\030\002\n\000\n\002\020\b\n\000\n\002\030\002\n\002\b\003\n\002\030\002\n\002\b\003\n\002\030\002\n\000\n\002\030\002\n\000\n\002\020 \n\000\n\002\030\002\n\002\b\002\n\002\020\021\n\002\030\002\n\000\n\002\030\002\n\000\n\002\030\002\n\000\n\002\030\002\n\000\n\002\030\002\n\002\b\002\n\002\030\002\n\002\030\002\n\002\b\003\n\002\030\002\n\000\n\002\030\002\n\002\030\002\n\002\b\007\n\002\030\002\n\002\b\002\n\002\030\002\n\002\b\003\n\002\030\002\n\002\b\002\n\002\030\002\n\002\b\002\n\002\030\002\n\002\b\003\n\002\030\002\n\002\b\003\n\002\030\002\n\002\030\002\n\002\b\005\n\002\030\002\n\002\030\002\n\002\b\t\n\002\030\002\n\002\b\003\n\002\030\002\n\000\n\002\030\002\n\002\b\002\n\002\030\002\n\002\b\002\n\002\030\002\n\002\b\002\n\002\030\002\n\002\b\002\n\002\030\002\n\002\b\003\n\002\030\002\n\002\b\002\n\002\030\002\n\000\n\002\030\002\n\002\030\002\n\000\n\002\030\002\n\002\b\004\n\002\030\002\n\000\n\002\030\002\n\002\b\005\n\002\030\002\n\002\b\002\bf\030\000 \0012\0020\001:\002\001J\030\020\002\032\b\022\004\022\0020\0040\0032\b\b\001\020\005\032\0020\006H'J\"\020\007\032\b\022\004\022\0020\0010\0032\b\b\001\020\b\032\0020\t2\b\b\001\020\005\032\0020\006H'J6\020\n\032\b\022\004\022\0020\0130\0032\b\b\001\020\f\032\0020\r2\b\b\001\020\005\032\0020\0062\b\b\001\020\016\032\0020\0172\b\b\001\020\020\032\0020\017H'J\"\020\021\032\b\022\004\022\0020\0130\0032\b\b\001\020\005\032\0020\0062\b\b\001\020\016\032\0020\017H'J,\020\022\032\b\022\004\022\0020\0230\0032\b\b\001\020\024\032\0020\0252\b\b\001\020\005\032\0020\0062\b\b\001\020\016\032\0020\017H'J,\020\026\032\b\022\004\022\0020\0270\0032\b\b\001\020\030\032\0020\0312\b\b\001\020\005\032\0020\0062\b\b\001\020\016\032\0020\017H'J\030\020\032\032\b\022\004\022\0020\0330\0032\b\b\001\020\005\032\0020\006H'J6\020\034\032\b\022\004\022\0020\0350\0032\b\b\001\020\005\032\0020\0062\b\b\001\020\036\032\0020\0172\b\b\001\020\037\032\0020\0172\b\b\001\020 \032\0020\006H'J\030\020!\032\b\022\004\022\0020\"0\0032\b\b\001\020\005\032\0020\006H'J\030\020#\032\b\022\004\022\0020$0\0032\b\b\001\020\005\032\0020\006H'J6\020%\032\b\022\004\022\0020\0350&2\b\b\001\020\005\032\0020\0062\b\b\001\020'\032\0020\0172\b\b\001\020\016\032\0020\0172\b\b\001\020(\032\0020\017H'J,\020)\032\b\022\004\022\0020*0\0032\b\b\001\020\005\032\0020\0062\b\b\001\020\016\032\0020\0172\b\b\001\020+\032\0020\017H'J6\020,\032\b\022\004\022\0020\0350\0032\b\b\001\020\005\032\0020\0062\b\b\001\020\016\032\0020\0172\b\b\001\020+\032\0020\0172\b\b\001\020 \032\0020\006H'J6\020-\032\b\022\004\022\0020.0\0032\b\b\001\020\005\032\0020\0062\b\b\001\020\036\032\0020\0172\b\b\001\020/\032\0020\0172\b\b\001\0200\032\00201H'J@\0202\032\b\022\004\022\002030\0032\b\b\001\0204\032\002052\b\b\001\020\005\032\0020\0062\b\b\001\020\036\032\0020\0172\b\b\001\020\037\032\0020\0172\b\b\001\0206\032\0020\017H'J6\0207\032\b\022\004\022\0020\0130\0032\b\b\001\020\005\032\0020\0062\b\b\001\020\036\032\0020\0172\b\b\001\020/\032\0020\0172\b\b\001\020\b\032\00208H'J\"\0209\032\b\022\004\022\0020\0130\0032\b\b\001\020\005\032\0020\0062\b\b\001\020\b\032\00208H'JI\020:\032\b\022\004\022\0020<0;2\b\b\001\020\005\032\0020\0062\b\b\001\020\036\032\0020\0172\b\b\001\020=\032\0020\0172\b\b\001\020/\032\0020\0172\b\b\001\020\b\032\0020>H\001\000\006\002\020?J,\020@\032\b\022\004\022\0020A0\0032\b\b\001\020\005\032\0020\0062\b\b\001\020\037\032\0020\0172\b\b\001\020B\032\0020\017H'J\030\020C\032\b\022\004\022\0020D0\0032\b\b\001\020\005\032\0020\006H'J,\020E\032\b\022\004\022\0020\0130\0032\b\b\001\020F\032\0020G2\b\b\001\020\005\032\0020\0062\b\b\001\020\016\032\0020\017H'J\"\020H\032\b\022\004\022\0020I0\0032\b\b\001\020J\032\0020K2\b\b\001\020\005\032\0020\006H'J\"\020L\032\b\022\004\022\0020\0130\0032\b\b\001\020\005\032\0020\0062\b\b\001\020\016\032\0020\017H'J\"\020M\032\b\022\004\022\0020\0130\0032\b\b\001\020N\032\0020O2\b\b\001\020\005\032\0020\006H'J,\020P\032\b\022\004\022\0020\0130\0032\b\b\001\020\005\032\0020\0062\b\b\001\020\016\032\0020\0172\b\b\001\020+\032\0020\017H'JJ\020Q\032\b\022\004\022\0020\0350&2\b\b\001\020\005\032\0020\0062\b\b\001\020'\032\0020\0172\b\b\001\020\016\032\0020\0172\b\b\001\020(\032\0020\0172\b\b\001\020R\032\0020\0172\b\b\001\020S\032\0020\017H'J,\020T\032\b\022\004\022\0020\0010U2\b\b\001\020V\032\0020W2\b\b\001\020\036\032\0020\0172\b\b\001\020\005\032\0020\006H'J6\020X\032\b\022\004\022\0020\0130\0032\b\b\001\020\005\032\0020\0062\b\b\001\020\036\032\0020\0172\b\b\001\020\016\032\0020\0172\b\b\001\0206\032\0020\017H'J,\020Y\032\b\022\004\022\0020\0130\0032\b\b\001\020\005\032\0020\0062\b\b\001\020\016\032\0020\0172\b\b\001\020F\032\0020\017H'J,\020Z\032\b\022\004\022\0020\0130\0032\b\b\001\020\005\032\0020\0062\b\b\001\020\016\032\0020\0172\b\b\001\020\020\032\0020\017H'J,\020[\032\b\022\004\022\0020\0130\0032\b\b\001\020\005\032\0020\0062\b\b\001\020\016\032\0020\0172\b\b\001\020\\\032\0020\006H'J\"\020]\032\b\022\004\022\0020\0130\0032\b\b\001\020\005\032\0020\0062\b\b\001\020\016\032\0020\017H'J,\020^\032\b\022\004\022\0020\0130\0032\b\b\001\020\005\032\0020\0062\b\b\001\020\016\032\0020\0172\b\b\001\020F\032\0020\017H'J6\020_\032\b\022\004\022\0020\0130&2\b\b\001\020\005\032\0020\0062\b\b\001\020'\032\0020\0172\b\b\001\020\016\032\0020\0172\b\b\001\020(\032\0020\017H'J6\020`\032\b\022\004\022\0020\0350&2\b\b\001\020\005\032\0020\0062\b\b\001\020'\032\0020\0172\b\b\001\020\016\032\0020\0172\b\b\001\020(\032\0020\017H'J\036\020a\032\016\022\n\022\b\022\004\022\0020c0b0\0032\b\b\001\020d\032\0020\006H'J(\020e\032\016\022\n\022\b\022\004\022\0020c0b0\0032\b\b\001\020\005\032\0020\0062\b\b\001\020f\032\0020\006H'J2\020g\032\016\022\n\022\b\022\004\022\0020c0b0\0032\b\b\001\020\005\032\0020\0062\b\b\001\020\036\032\0020\0172\b\b\001\020f\032\0020\006H'J6\020h\032\b\022\004\022\0020\0350&2\b\b\001\020\005\032\0020\0062\b\b\001\020'\032\0020\0172\b\b\001\020\016\032\0020\0172\b\b\001\020(\032\0020\017H'J,\020i\032\b\022\004\022\0020\0130\0032\b\b\001\020\005\032\0020\0062\b\b\001\020\016\032\0020\0172\b\b\001\020F\032\0020\017H'J6\020j\032\b\022\004\022\0020\0130&2\b\b\001\020\005\032\0020\0062\b\b\001\020'\032\0020\0172\b\b\001\020\016\032\0020\0172\b\b\001\020(\032\0020\017H'J6\020k\032\b\022\004\022\0020\0350&2\b\b\001\020\005\032\0020\0062\b\b\001\020'\032\0020\0172\b\b\001\020\016\032\0020\0172\b\b\001\020(\032\0020\017H'J6\020l\032\b\022\004\022\0020\0350&2\b\b\001\020\005\032\0020\0062\b\b\001\020'\032\0020\0172\b\b\001\020\016\032\0020\0172\b\b\001\020(\032\0020\017H'J6\020m\032\b\022\004\022\0020\0350&2\b\b\001\020\005\032\0020\0062\b\b\001\020'\032\0020\0172\b\b\001\020\016\032\0020\0172\b\b\001\020(\032\0020\017H'J,\020n\032\b\022\004\022\0020o0\0032\b\b\001\020\005\032\0020\0062\b\b\001\020\036\032\0020\0172\b\b\001\020/\032\0020\017H'J\"\020p\032\b\022\004\022\0020o0\0032\b\b\001\020\005\032\0020\0062\b\b\001\020q\032\0020rH'J\030\020s\032\b\022\004\022\0020t0\0032\b\b\001\020\005\032\0020\006H'J,\020u\032\b\022\004\022\0020v0\0032\b\b\001\020\005\032\0020\0062\b\b\001\020\016\032\0020\0172\b\b\001\020+\032\0020\017H'J6\020w\032\b\022\004\022\0020x0U2\b\b\001\020\005\032\0020\0062\b\b\001\020\036\032\0020\0172\b\b\001\020y\032\0020z2\b\b\001\020{\032\0020|H'J,\020}\032\b\022\004\022\0020~0\0032\b\b\001\020\005\032\0020\0062\b\b\001\020'\032\0020\0172\b\b\001\020\032\0020\017H'JK\020\001\032\b\022\004\022\0020\0350&2\b\b\001\020\005\032\0020\0062\b\b\001\020'\032\0020\0172\b\b\001\020\016\032\0020\0172\b\b\001\020(\032\0020\0172\b\b\001\020R\032\0020\0172\b\b\001\020S\032\0020\017H'JC\020\001\032\t\022\005\022\0030\0010&2\b\b\001\020\005\032\0020\0062\b\b\001\020'\032\0020\0172\b\b\001\020\016\032\0020\0172\b\b\001\020(\032\0020\0172\t\b\001\020\001\032\0020\017H'J7\020\001\032\b\022\004\022\0020\0350&2\b\b\001\020\005\032\0020\0062\b\b\001\020'\032\0020\0172\b\b\001\020\016\032\0020\0172\b\b\001\020(\032\0020\017H'J8\020\001\032\t\022\005\022\0030\0010&2\b\b\001\020\005\032\0020\0062\b\b\001\020'\032\0020\0172\b\b\001\020\016\032\0020\0172\b\b\001\020(\032\0020\017H'J8\020\001\032\t\022\005\022\0030\0010\0032\b\b\001\020\005\032\0020\0062\b\b\001\020\036\032\0020\0172\b\b\001\020\037\032\0020\0172\b\b\001\0206\032\0020\017H'J*\020\001\032\017\022\013\022\t\022\004\022\0020G0\0010\0032\b\b\001\020\016\032\0020\0172\b\b\001\020\005\032\0020\006H'J%\020\001\032\t\022\005\022\0030\0010\0032\b\b\001\020\005\032\0020\0062\t\b\001\020\001\032\0020\006H'J+\020\001\032\020\022\f\022\n\022\005\022\0030\0010\0010\0032\b\b\001\020\005\032\0020\0062\b\b\001\020\016\032\0020\017H'J\032\020\001\032\t\022\005\022\0030\0010\0032\b\b\001\020\005\032\0020\006H'J8\020\001\032\t\022\005\022\0030\0010\0032\b\b\001\020\005\032\0020\0062\b\b\001\020'\032\0020\0172\b\b\001\020\016\032\0020\0172\b\b\001\020+\032\0020\017H'J$\020\001\032\t\022\005\022\0030\0010&2\b\b\001\020\005\032\0020\0062\b\b\001\020'\032\0020\017H'J%\020\001\032\t\022\005\022\0030\0010&2\b\b\001\020\005\032\0020\0062\t\b\001\020\001\032\0020\006H'JD\020\001\032\t\022\005\022\0030\0010\0032\t\b\001\020\b\032\0030\0012\b\b\001\020\005\032\0020\0062\b\b\001\020'\032\0020\0172\b\b\001\020\016\032\0020\0172\t\b\001\020\001\032\0020\017H'JC\020\001\032\t\022\005\022\0030\0010\0032\t\b\001\020\b\032\0030\0012\b\b\001\020\005\032\0020\0062\b\b\001\020'\032\0020\0172\b\b\001\020\016\032\0020\0172\b\b\001\020+\032\0020\017H'J.\020\001\032\t\022\005\022\0030\0010\0032\b\b\001\020\005\032\0020\0062\b\b\001\020\016\032\0020\0172\b\b\001\020+\032\0020\017H'J%\020\001\032\t\022\005\022\0030\0010&2\t\b\001\020\b\032\0030\0012\b\b\001\020\005\032\0020\006H'J%\020\001\032\t\022\005\022\0030\0010U2\t\b\001\020\b\032\0030\0012\b\b\001\020\005\032\0020\006H'J-\020\001\032\b\022\004\022\0020\0130\0032\b\b\001\020\005\032\0020\0062\b\b\001\020\036\032\0020\0172\b\b\001\020/\032\0020\017H'J7\020\001\032\b\022\004\022\0020\0350&2\b\b\001\020\005\032\0020\0062\b\b\001\020'\032\0020\0172\b\b\001\020\016\032\0020\0172\b\b\001\020(\032\0020\017H'J-\020\001\032\b\022\004\022\0020\0350\0032\b\b\001\020\005\032\0020\0062\b\b\001\020\016\032\0020\0172\b\b\001\020+\032\0020\017H'J7\020\001\032\b\022\004\022\0020\0350\0032\b\b\001\020\005\032\0020\0062\b\b\001\020\036\032\0020\0172\b\b\001\020\037\032\0020\0172\b\b\001\0206\032\0020\017H'J\031\020\001\032\b\022\004\022\0020\0130\0032\b\b\001\020\005\032\0020\006H'J%\020\001\032\t\022\005\022\0030\0010&2\t\b\001\020\b\032\0030\0012\b\b\001\020\005\032\0020\006H'J-\020\001\032\b\022\004\022\0020o0\0032\b\b\001\020\005\032\0020\0062\b\b\001\020\036\032\0020\0172\b\b\001\020/\032\0020\017H'JB\020\001\032\t\022\005\022\0030\0010;2\b\b\001\020\005\032\0020\0062\b\b\001\020\036\032\0020\0172\b\b\001\020=\032\0020\0172\b\b\001\020/\032\0020\017H\001\000\006\003\020\001J9\020\001\032\b\022\004\022\0020\0350\0032\n\b\001\020\001\032\0030\0012\b\b\001\020\005\032\0020\0062\b\b\001\020\016\032\0020\0172\b\b\001\020+\032\0020\017H'J9\020\001\032\b\022\004\022\0020\0350\0032\n\b\001\020\001\032\0030\0012\b\b\001\020\005\032\0020\0062\b\b\001\020\016\032\0020\0172\b\b\001\020+\032\0020\017H'JC\020\001\032\b\022\004\022\0020\0350\0032\n\b\001\020\001\032\0030\0012\b\b\001\020\005\032\0020\0062\b\b\001\020\036\032\0020\0172\b\b\001\020\037\032\0020\0172\b\b\001\0206\032\0020\017H'J8\020\001\032\b\022\004\022\0020\0130\0032\t\b\001\020\001\032\0020~2\b\b\001\020\005\032\0020\0062\b\b\001\020'\032\0020\0172\b\b\001\020\032\0020\017H'J$\020\001\032\b\022\004\022\0020\0130\0032\t\b\001\020\b\032\0030\0012\b\b\001\020\005\032\0020\006H'J$\020\001\032\b\022\004\022\0020\0130U2\t\b\001\020\b\032\0030\0012\b\b\001\020\005\032\0020\006H'J#\020\001\032\b\022\004\022\0020\0130\0032\b\b\001\020\005\032\0020\0062\b\b\001\020\016\032\0020\017H'J/\020\001\032\t\022\005\022\0030\0010;2\b\b\001\020\005\032\0020\0062\t\b\001\020\b\032\0030\001H\001\000\006\003\020\001JB\020\001\032\b\022\004\022\0020\0350\0032\t\b\001\020\b\032\0030\0012\b\b\001\020\005\032\0020\0062\b\b\001\020'\032\0020\0172\b\b\001\020\016\032\0020\0172\b\b\001\020+\032\0020\017H'J7\020\001\032\b\022\004\022\0020\0350\0032\b\b\001\0204\032\002052\b\b\001\020\005\032\0020\0062\b\b\001\020\016\032\0020\0172\b\b\001\020 \032\0020\006H'J7\020\001\032\b\022\004\022\002030\0032\b\b\001\0204\032\002052\b\b\001\020\005\032\0020\0062\b\b\001\020'\032\0020\0172\b\b\001\020\016\032\0020\017H'JM\020\001\032\t\022\005\022\0030\0010;2\b\b\001\020\005\032\0020\0062\b\b\001\020\036\032\0020\0172\b\b\001\020=\032\0020\0172\b\b\001\020/\032\0020\0172\t\b\001\020\b\032\0030\001H\001\000\006\003\020\001JM\020\001\032\t\022\005\022\0030\0010;2\b\b\001\020\005\032\0020\0062\b\b\001\020\036\032\0020\0172\b\b\001\020=\032\0020\0172\b\b\001\020/\032\0020\0172\t\b\001\020\b\032\0030\001H\001\000\006\003\020\001J7\020\001\032\b\022\004\022\0020\0350\0032\b\b\001\020\005\032\0020\0062\b\b\001\020\036\032\0020\0172\b\b\001\020\037\032\0020\0172\b\b\001\0206\032\0020\017H'J-\020\001\032\b\022\004\022\0020\0350\0032\b\b\001\020\005\032\0020\0062\b\b\001\020\016\032\0020\0172\b\b\001\020+\032\0020\017H'J-\020\001\032\b\022\004\022\0020\0130\0032\b\b\001\020\005\032\0020\0062\b\b\001\020\016\032\0020\0172\b\b\001\020+\032\0020\017H'J-\020\001\032\b\022\004\022\0020\0130\0032\b\b\001\020\005\032\0020\0062\b\b\001\020\016\032\0020\0172\b\b\001\020+\032\0020\017H'J-\020\001\032\b\022\004\022\0020\0130U2\b\b\001\020\037\032\0020\0172\b\b\001\020B\032\0020\0172\b\b\001\020\005\032\0020\006H'J:\020\001\032\b\022\004\022\0020\0130\0032\n\b\001\020\001\032\0030\0012\b\b\001\020\005\032\0020\0062\b\b\001\020\016\032\0020\0172\t\b\001\020\001\032\0020\017H'J%\020\001\032\b\022\004\022\0020\0130\0032\n\b\001\020\001\032\0030\0012\b\b\001\020\005\032\0020\006H'J$\020\001\032\t\022\005\022\0030\0010\0032\b\b\001\020\005\032\0020\0062\b\b\001\020f\032\0020\006H'J9\020\001\032\b\022\004\022\0020\0130\0032\n\b\001\020\001\032\0030\0012\b\b\001\020\016\032\0020\0172\b\b\001\020B\032\0020\0172\b\b\001\020\005\032\0020\006H'J9\020\001\032\b\022\004\022\0020\0130U2\n\b\001\020\001\032\0030\0012\b\b\001\020\016\032\0020\0172\b\b\001\020B\032\0020\0172\b\b\001\020\005\032\0020\006H'J/\020\001\032\b\022\004\022\0020\0130\0032\n\b\001\020\001\032\0030\0012\b\b\001\020\005\032\0020\0062\b\b\001\020\016\032\0020\017H'J9\020\001\032\b\022\004\022\0020\0130\0032\n\b\001\020\001\032\0030\0012\b\b\001\020\005\032\0020\0062\b\b\001\020\016\032\0020\0172\b\b\001\020F\032\0020\017H'J9\020\001\032\b\022\004\022\0020\0130\0032\n\b\001\020\001\032\0030\0012\b\b\001\020\005\032\0020\0062\b\b\001\020\016\032\0020\0172\b\b\001\020\020\032\0020\017H'J5\020\001\032\020\022\f\022\n\022\005\022\0030\0010\0010\0032\b\b\001\020\f\032\0020\r2\b\b\001\020\005\032\0020\0062\b\b\001\020\016\032\0020\017H'J/\020\001\032\b\022\004\022\0020\0130\0032\n\b\001\020\001\032\0030\0012\b\b\001\020\005\032\0020\0062\b\b\001\020\016\032\0020\017H'J/\020\001\032\b\022\004\022\0020\0130\0032\n\b\001\020\001\032\0030\0012\b\b\001\020\005\032\0020\0062\b\b\001\020\016\032\0020\017H'J%\020\001\032\t\022\005\022\0030\0010&2\t\b\001\020\b\032\0030\0012\b\b\001\020\005\032\0020\006H'J%\020\001\032\t\022\005\022\0030\0010&2\t\b\001\020\b\032\0030\0012\b\b\001\020\005\032\0020\006H'J#\020\001\032\b\022\004\022\0020o0\0032\b\b\001\020\005\032\0020\0062\b\b\001\020'\032\0020\017H'J-\020\001\032\b\022\004\022\0020o0\0032\b\b\001\020\005\032\0020\0062\b\b\001\020'\032\0020\0172\b\b\001\020\032\0020\017H'J#\020\001\032\b\022\004\022\0020o0\0032\b\b\001\020\005\032\0020\0062\b\b\001\020'\032\0020\017H'J0\020\001\032\t\022\005\022\0030\0010\0032\b\b\001\020\005\032\0020\0062\b\b\001\020'\032\0020\0172\n\b\001\020\001\032\0030\001H'J:\020\001\032\t\022\005\022\0030\0010\0032\b\b\001\020\005\032\0020\0062\b\b\001\020\036\032\0020\0172\b\b\001\020/\032\0020\0172\n\b\001\020\001\032\0030\001H'J:\020\001\032\t\022\005\022\0030\0010\0032\b\b\001\020\005\032\0020\0062\b\b\001\020'\032\0020\0172\b\b\001\020\032\0020\0172\n\b\001\020\001\032\0030\001H'J:\020\001\032\t\022\005\022\0030\0010\0032\b\b\001\020\005\032\0020\0062\b\b\001\020\036\032\0020\0172\b\b\001\020/\032\0020\0172\n\b\001\020\001\032\0030\001H'J&\020\001\032\t\022\005\022\0030\0010\0032\b\b\001\020\005\032\0020\0062\n\b\001\020\001\032\0030\001H'J$\020\001\032\b\022\004\022\0020\0010\0032\t\b\001\020\b\032\0030\0012\b\b\001\020\005\032\0020\006H'\002\004\n\002\b\031\006\001"}, d2 = {"Lcom/immediasemi/blink/api/retrofit/BlinkWebService;", "", "accountOptions", "Lrx/Observable;", "Lcom/immediasemi/blink/models/AccountOptionsResponse;", "tier", "", "acknowledgeNotification", "body", "Lcom/immediasemi/blink/api/retrofit/AcknowledgeNotificationBody;", "activateSiren", "Lcom/immediasemi/blink/models/BlinkData;", "sirenDurationBody", "Lcom/immediasemi/blink/api/retrofit/SirenDurationBody;", "network", "", "siren", "activateSirens", "addCamera", "Lcom/immediasemi/blink/models/AddCameraResponseBody;", "addCameraBody", "Lcom/immediasemi/blink/api/retrofit/AddCameraBody;", "addSiren", "Lcom/immediasemi/blink/models/AddSirenResponse;", "addSirenNetworkBody", "Lcom/immediasemi/blink/api/retrofit/AddSirenNetworkBody;", "appUpdateStatus", "Lcom/immediasemi/blink/api/retrofit/UpdateStatusBody;", "armDisarmNetwork", "Lcom/immediasemi/blink/models/Command;", "accountId", "networkId", "type", "batteryUsage", "Lcom/immediasemi/blink/models/BatteryUsage;", "blinkStabilityStatus", "Lcom/immediasemi/blink/api/retrofit/StatusBoxBody;", "bulkDownloadClips", "Lrx/Single;", "account", "syncModuleId", "cameraCommandStatus", "Lcom/immediasemi/blink/models/CameraStatus;", "camera", "cameraMotion", "changeEmail", "Lcom/immediasemi/blink/api/retrofit/ChangeAccountDetailPinResponse;", "clientId", "changeEmailRequest", "Lcom/immediasemi/blink/api/retrofit/ChangeEmailRequest;", "changeOwlWifi", "Lcom/immediasemi/blink/api/retrofit/OwlAddBody;", "onboardingStartRequest", "Lcom/immediasemi/blink/api/retrofit/OnboardingStartRequest;", "owlId", "changePassword", "Lcom/immediasemi/blink/api/retrofit/TokenizedChangePassword;", "changePasswordUnauthenticated", "changePhoneNumber", "Lretrofit2/Response;", "Lcom/immediasemi/blink/api/retrofit/ChangePhoneNumberResponse;", "userId", "Lcom/immediasemi/blink/api/retrofit/ChangePhoneNumberBody;", "(Ljava/lang/String;JJJLcom/immediasemi/blink/api/retrofit/ChangePhoneNumberBody;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "commandPolling", "Lcom/immediasemi/blink/models/Commands;", "commandId", "contactBlink", "Lcom/immediasemi/blink/api/retrofit/ContactBlink;", "createProgram", "program", "Lcom/immediasemi/blink/scheduling/Program;", "createSystem", "Lcom/immediasemi/blink/models/ANetwork;", "addNetworkBody", "Lcom/immediasemi/blink/api/retrofit/AddNetworkBody;", "deactivateSirens", "deleteAccount", "deleteAccountBody", "Lcom/immediasemi/blink/api/retrofit/DeleteAccountBody;", "deleteCamera", "deleteClip", "clipId", "manifestId", "deleteMediaCall", "Lretrofit2/Call;", "mediaIdList", "Lcom/immediasemi/blink/api/retrofit/MediaIdListBody;", "deleteOwl", "deleteProgram", "deleteSirens", "deleteSyncModule", "number", "deleteSystem", "disableProgram", "disableSyncModuleBackup", "disableUsbStorage", "downloadFirmware", "Lretrofit2/adapter/rxjava/Result;", "Lokhttp3/ResponseBody;", "url", "downloadFirmwareUpdate", "serial", "downloadOwlFirmwareUpdate", "ejectUsbStorage", "enableProgram", "enableSyncModuleBackup", "enableUsbStorage", "eraseUsbStorage", "formatUsbStorage", "generateChangePasswordPinCode", "Lcom/immediasemi/blink/api/retrofit/SendPinResponse;", "generateChangePasswordPinCodeUnauthenticated", "request", "Lcom/immediasemi/blink/api/retrofit/ResetPasswordUnauthenticatedRequest;", "getAccount", "Lcom/immediasemi/blink/models/AccountRetrievalResponse;", "getCameraConfig", "Lcom/immediasemi/blink/models/CameraConfig;", "getChangedMedia", "Lcom/immediasemi/blink/models/ChangedMedia;", "since", "Lorg/threeten/bp/OffsetDateTime;", "page", "", "getClientOptions", "Lcom/immediasemi/blink/utils/clientoption/ClientOptionsResponse;", "client", "getClipCommandId", "getClipListManifest", "Lcom/immediasemi/blink/api/retrofit/ClipsResponse;", "manifestCommandId", "getClipListManifestCommandId", "getLocalStorageStatus", "Lcom/immediasemi/blink/api/retrofit/LocalStorageStatusResponse;", "getOwlConfig", "Lcom/immediasemi/blink/models/OwlConfigInfo;", "getPrograms", "", "getRegions", "Lcom/immediasemi/blink/models/QuickRegionInfo;", "country", "getSirens", "", "Lcom/immediasemi/blink/models/Siren;", "getSirensForAllNetworks", "Lcom/immediasemi/blink/utils/SirensReponse;", "getZones", "Lcom/immediasemi/blink/api/retrofit/AdvancedCameraZones;", "homescreenV3", "Lcom/immediasemi/blink/utils/sync/HomescreenV3;", "identifyDevice", "Lcom/immediasemi/blink/api/retrofit/IdentifyDeviceResponse;", "serialNumber", "liveViewOwl", "Lcom/immediasemi/blink/api/retrofit/PirPollingResponse;", "Lcom/immediasemi/blink/api/retrofit/LiveViewBody;", "owl", "liveViewV5", "loadCameraStatus", "Lcom/immediasemi/blink/models/SignalStrength;", "login", "Lcom/immediasemi/blink/api/retrofit/AuthenticationResponse;", "Lcom/immediasemi/blink/api/retrofit/LoginBody;", "loginCall", "logout", "mountUsb", "refreshCameraStatus", "refreshOwlStatus", "regions", "register", "Lcom/immediasemi/blink/api/retrofit/RegisterBody;", "resendChangeEmailPinCode", "resendClientVerificationCode", "Lcom/immediasemi/blink/api/retrofit/ResendClientVerificationCodeResponse;", "(Ljava/lang/String;JJJLkotlin/coroutines/Continuation;)Ljava/lang/Object;", "saveCalibrateTemperature", "calibrate", "Lcom/immediasemi/blink/api/retrofit/Calibrate;", "saveCameraSettings", "updateCameraBody", "Lcom/immediasemi/blink/api/retrofit/UpdateCameraBody;", "saveOwlSettings", "updateOwlBody", "Lcom/immediasemi/blink/models/UpdateOwlBody;", "sendClientOptions", "clientOptions", "sendLogs", "Lcom/immediasemi/blink/api/retrofit/LogsBody;", "sendLogsCall", "sendSystemOfflineHelpEmaail", "setTivLock", "Lcom/immediasemi/blink/api/retrofit/SetTivLockResponse;", "Lcom/immediasemi/blink/api/retrofit/TivLockBody;", "(Ljava/lang/String;Lcom/immediasemi/blink/api/retrofit/TivLockBody;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "setZones", "startOnboarding", "startOwlOnboarding", "submitClientVerificationCode", "Lcom/immediasemi/blink/api/retrofit/SubmitVerificationResponse;", "Lcom/immediasemi/blink/api/retrofit/SubmitVerificationRequest;", "(Ljava/lang/String;JJJLcom/immediasemi/blink/api/retrofit/SubmitVerificationRequest;Lkotlin/coroutines/Continuation;)Ljava/lang/Object;", "submitPhoneNumberVerificationCode", "takeOwlThumbnail", "takeThumbnail", "tempAlertDisable", "tempAlertEnable", "terminateCommand", "terminateOnboardingCommand", "terminateOnboardingBody", "Lcom/immediasemi/blink/api/retrofit/TerminateOnboardingBody;", "command", "updateAccount", "updateAccountBody", "Lcom/immediasemi/blink/api/retrofit/UpdateAccountBody;", "updateCheck", "Lcom/immediasemi/blink/api/retrofit/UpdateCheckBodyReceiveBody;", "updateCommand", "updateCommandRequest", "Lcom/immediasemi/blink/api/requests/onboarding/OnboardingCommandUpdate/UpdateCommandRequest;", "updateCommandSync", "updateNetworkSaveAllLiveViews", "Lcom/immediasemi/blink/api/retrofit/UpdateNetworkSaveAllLiveViews;", "updateProgram", "updateProgramRequest", "Lcom/immediasemi/blink/scheduling/UpdateProgramRequest;", "updateSiren", "sirenNameBody", "Lcom/immediasemi/blink/api/retrofit/SirenNameBody;", "updateSirens", "updateSystem", "updateSystemNameBody", "Lcom/immediasemi/blink/api/retrofit/UpdateSystemNameBody;", "updateTimezone", "updateTimezoneBody", "Lcom/immediasemi/blink/api/retrofit/UpdateTimezoneBody;", "validateEmailAddress", "Lcom/immediasemi/blink/createaccount/ValidationResponse;", "Lcom/immediasemi/blink/createaccount/ValidateEmailBody;", "validatePassword", "Lcom/immediasemi/blink/createaccount/ValidatePasswordBody;", "verificationEmail", "verificationPinClient", "verificationPinEmail", "verifyAccountPIN", "Lcom/immediasemi/blink/api/retrofit/PinVerificationResponse;", "verifyPinBody", "Lcom/immediasemi/blink/api/retrofit/VerifyPinBody;", "verifyChangeEmailPinCode", "verifyClientPIN", "verifyPasswordChangePinCode", "verifyPasswordChangePinCodeUnauthenticated", "videoOptionsSetter", "Lcom/immediasemi/blink/utils/AutoPurgeSetterBody;", "Companion", "app_prodRelease"}, k = 1, mv = {1, 4, 0})
        public interface BlinkWebService {
        public static final Companion Companion = Companion.$$INSTANCE;
  
        public static final String HTTP_APP_BUILD = "APP-BUILD";
  
        public static final String LOCALE = "LOCALE";
  
        public static final String TOKEN_AUTH_HEADER = "TOKEN-AUTH";
  
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
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account_id}/networks/{network}/sync_modules/{sync_module_id}/local_storage/bulk_download")
        Single<Command> bulkDownloadClips(@Path("tier") String paramString, @Path("account_id") long paramLong1, @Path("network") long paramLong2, @Path("sync_module_id") long paramLong3);
  
        @GET("https://rest-{tier}.immedia-semi.com/network/{network}/camera/{camera}")
        Observable<CameraStatus> cameraCommandStatus(@Path("tier") String paramString, @Path("network") long paramLong1, @Path("camera") long paramLong2);
  
        @POST("https://rest-{tier}.immedia-semi.com/network/{network}/camera/{camera}/{type}")
        Observable<Command> cameraMotion(@Path("tier") String paramString1, @Path("network") long paramLong1, @Path("camera") long paramLong2, @Path("type") String paramString2);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/{accountId}/client/{clientId}/email_change/")
        Observable<ChangeAccountDetailPinResponse> changeEmail(@Path("tier") String paramString, @Path("accountId") long paramLong1, @Path("clientId") long paramLong2, @Body ChangeEmailRequest paramChangeEmailRequest);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{accountId}/networks/{networkId}/owls/{owlId}/change_wifi")
        Observable<OwlAddBody> changeOwlWifi(@Body OnboardingStartRequest paramOnboardingStartRequest, @Path("tier") String paramString, @Path("accountId") long paramLong1, @Path("networkId") long paramLong2, @Path("owlId") long paramLong3);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/{accountId}/client/{clientId}/password_change/")
        Observable<BlinkData> changePassword(@Path("tier") String paramString, @Path("accountId") long paramLong1, @Path("clientId") long paramLong2, @Body TokenizedChangePassword paramTokenizedChangePassword);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/password_change/")
        Observable<BlinkData> changePasswordUnauthenticated(@Path("tier") String paramString, @Body TokenizedChangePassword paramTokenizedChangePassword);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v5/accounts/{account_id}/users/{user_id}/clients/{client_id}/phone_number_change/")
        Object changePhoneNumber(@Path("tier") String paramString, @Path("account_id") long paramLong1, @Path("user_id") long paramLong2, @Path("client_id") long paramLong3, @Body ChangePhoneNumberBody paramChangePhoneNumberBody, Continuation<? super Response<ChangePhoneNumberResponse>> paramContinuation);
  
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
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account_id}/networks/{network}/sync_modules/{sync_module_id}/local_storage/manifest/{manifest_id}/clip/delete/{clip_id}")
        Single<Command> deleteClip(@Path("tier") String paramString, @Path("account_id") long paramLong1, @Path("network") long paramLong2, @Path("sync_module_id") long paramLong3, @Path("clip_id") long paramLong4, @Path("manifest_id") long paramLong5);
  
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
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account_id}/networks/{network}/sync_modules/{sync_module_id}/local_storage/sm_backup/disable")
        Single<BlinkData> disableSyncModuleBackup(@Path("tier") String paramString, @Path("account_id") long paramLong1, @Path("network") long paramLong2, @Path("sync_module_id") long paramLong3);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account_id}/networks/{network}/sync_modules/{sync_module_id}/local_storage/disable")
        Single<Command> disableUsbStorage(@Path("tier") String paramString, @Path("account_id") long paramLong1, @Path("network") long paramLong2, @Path("sync_module_id") long paramLong3);
  
        @GET
        Observable<Result<ResponseBody>> downloadFirmware(@Url String paramString);
  
        @GET("https://rest-{tier}.immedia-semi.com/api/v1/sync_modules/{serial}/fw_update")
        Observable<Result<ResponseBody>> downloadFirmwareUpdate(@Path("tier") String paramString1, @Path("serial") String paramString2);
  
        @GET("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{accountId}/owls/{serial}/fw_update")
        Observable<Result<ResponseBody>> downloadOwlFirmwareUpdate(@Path("tier") String paramString1, @Path("accountId") long paramLong, @Path("serial") String paramString2);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account_id}/networks/{network}/sync_modules/{sync_module_id}/local_storage/eject")
        Single<Command> ejectUsbStorage(@Path("tier") String paramString, @Path("account_id") long paramLong1, @Path("network") long paramLong2, @Path("sync_module_id") long paramLong3);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/networks/{network}/programs/{program}/enable")
        Observable<BlinkData> enableProgram(@Path("tier") String paramString, @Path("network") long paramLong1, @Path("program") long paramLong2);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account_id}/networks/{network}/sync_modules/{sync_module_id}/local_storage/sm_backup/enable")
        Single<BlinkData> enableSyncModuleBackup(@Path("tier") String paramString, @Path("account_id") long paramLong1, @Path("network") long paramLong2, @Path("sync_module_id") long paramLong3);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account_id}/networks/{network}/sync_modules/{sync_module_id}/local_storage/enable")
        Single<Command> enableUsbStorage(@Path("tier") String paramString, @Path("account_id") long paramLong1, @Path("network") long paramLong2, @Path("sync_module_id") long paramLong3);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account_id}/networks/{network}/sync_modules/{sync_module_id}/local_storage/erase")
        Single<Command> eraseUsbStorage(@Path("tier") String paramString, @Path("account_id") long paramLong1, @Path("network") long paramLong2, @Path("sync_module_id") long paramLong3);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account_id}/networks/{network}/sync_modules/{sync_module_id}/local_storage/format")
        Single<Command> formatUsbStorage(@Path("tier") String paramString, @Path("account_id") long paramLong1, @Path("network") long paramLong2, @Path("sync_module_id") long paramLong3);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/{accountId}/client/{clientId}/password_change/pin/generate/")
        Observable<SendPinResponse> generateChangePasswordPinCode(@Path("tier") String paramString, @Path("accountId") long paramLong1, @Path("clientId") long paramLong2);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/password_change/pin/generate/")
        Observable<SendPinResponse> generateChangePasswordPinCodeUnauthenticated(@Path("tier") String paramString, @Body ResetPasswordUnauthenticatedRequest paramResetPasswordUnauthenticatedRequest);
  
        @GET("https://rest-{tier}.immedia-semi.com/account")
        Observable<AccountRetrievalResponse> getAccount(@Path("tier") String paramString);
  
        @GET("https://rest-{tier}.immedia-semi.com/network/{network}/camera/{camera}/config")
        Observable<CameraConfig> getCameraConfig(@Path("tier") String paramString, @Path("network") long paramLong1, @Path("camera") long paramLong2);
  
        @GET("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{accountId}/media/changed")
        Call<ChangedMedia> getChangedMedia(@Path("tier") String paramString, @Path("accountId") long paramLong, @Query("since") OffsetDateTime paramOffsetDateTime, @Query("page") int paramInt);
  
        @GET("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account}/clients/{client}/options")
        Observable<ClientOptionsResponse> getClientOptions(@Path("tier") String paramString, @Path("account") long paramLong1, @Path("client") long paramLong2);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account_id}/networks/{network}/sync_modules/{sync_module_id}/local_storage/manifest/{manifest_id}/clip/request/{clip_id}")
        Single<Command> getClipCommandId(@Path("tier") String paramString, @Path("account_id") long paramLong1, @Path("network") long paramLong2, @Path("sync_module_id") long paramLong3, @Path("clip_id") long paramLong4, @Path("manifest_id") long paramLong5);
  
        @GET("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account_id}/networks/{network}/sync_modules/{sync_module_id}/local_storage/manifest/request/{command}")
        Single<ClipsResponse> getClipListManifest(@Path("tier") String paramString, @Path("account_id") long paramLong1, @Path("network") long paramLong2, @Path("sync_module_id") long paramLong3, @Path("command") long paramLong4);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account_id}/networks/{network}/sync_modules/{sync_module_id}/local_storage/manifest/request")
        Single<Command> getClipListManifestCommandId(@Path("tier") String paramString, @Path("account_id") long paramLong1, @Path("network") long paramLong2, @Path("sync_module_id") long paramLong3);
  
        @GET("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account_id}/networks/{network}/sync_modules/{sync_module_id}/local_storage/status")
        Single<LocalStorageStatusResponse> getLocalStorageStatus(@Path("tier") String paramString, @Path("account_id") long paramLong1, @Path("network") long paramLong2, @Path("sync_module_id") long paramLong3);
  
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
  
        @GET("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account}/networks/{network}/cameras/{camera}/zones")
        Observable<AdvancedCameraZones> getZones(@Path("tier") String paramString, @Path("account") long paramLong1, @Path("network") long paramLong2, @Path("camera") long paramLong3);
  
        @GET("https://rest-{tier}.immedia-semi.com/api/v3/accounts/{account}/homescreen")
        Single<HomescreenV3> homescreenV3(@Path("tier") String paramString, @Path("account") long paramLong);
  
        @GET("https://rest-{tier}.immedia-semi.com/api/v2/devices/identify/{serialNumber}")
        Single<IdentifyDeviceResponse> identifyDevice(@Path("tier") String paramString1, @Path("serialNumber") String paramString2);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account}/networks/{network}/owls/{owl}/liveview")
        Observable<PirPollingResponse> liveViewOwl(@Body LiveViewBody paramLiveViewBody, @Path("tier") String paramString, @Path("account") long paramLong1, @Path("network") long paramLong2, @Path("owl") long paramLong3);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v5/accounts/{account}/networks/{network}/cameras/{camera}/liveview")
        Observable<PirPollingResponse> liveViewV5(@Body LiveViewBody paramLiveViewBody, @Path("tier") String paramString, @Path("account") long paramLong1, @Path("network") long paramLong2, @Path("camera") long paramLong3);
  
        @GET("https://rest-{tier}.immedia-semi.com/network/{network}/camera/{camera}/signals")
        Observable<SignalStrength> loadCameraStatus(@Path("tier") String paramString, @Path("network") long paramLong1, @Path("camera") long paramLong2);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v5/account/login")
        Single<AuthenticationResponse> login(@Body LoginBody paramLoginBody, @Path("tier") String paramString);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v5/account/login")
        Call<AuthenticationResponse> loginCall(@Body LoginBody paramLoginBody, @Path("tier") String paramString);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/{accountId}/client/{clientId}/logout/")
        Observable<BlinkData> logout(@Path("tier") String paramString, @Path("accountId") long paramLong1, @Path("clientId") long paramLong2);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account_id}/networks/{network}/sync_modules/{sync_module_id}/local_storage/mount")
        Single<Command> mountUsb(@Path("tier") String paramString, @Path("account_id") long paramLong1, @Path("network") long paramLong2, @Path("sync_module_id") long paramLong3);
  
        @POST("https://rest-{tier}.immedia-semi.com/network/{network}/camera/{camera}/status")
        Observable<Command> refreshCameraStatus(@Path("tier") String paramString, @Path("network") long paramLong1, @Path("camera") long paramLong2);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{accountId}/networks/{networkId}/owls/{owlId}/status")
        Observable<Command> refreshOwlStatus(@Path("tier") String paramString, @Path("accountId") long paramLong1, @Path("networkId") long paramLong2, @Path("owlId") long paramLong3);
  
        @GET("https://rest-prod.immedia-semi.com/regions?locale=US")
        Observable<BlinkData> regions(@Path("tier") String paramString);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v5/account/register")
        Single<AuthenticationResponse> register(@Body RegisterBody paramRegisterBody, @Path("tier") String paramString);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/{accountId}/client/{clientId}/email_change/pin/resend")
        Observable<SendPinResponse> resendChangeEmailPinCode(@Path("tier") String paramString, @Path("accountId") long paramLong1, @Path("clientId") long paramLong2);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v5/accounts/{account_id}/users/{user_id}/clients/{client_id}/client_verification/pin/resend/")
        Object resendClientVerificationCode(@Path("tier") String paramString, @Path("account_id") long paramLong1, @Path("user_id") long paramLong2, @Path("client_id") long paramLong3, Continuation<? super Response<ResendClientVerificationCodeResponse>> paramContinuation);
  
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
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/account/tiv")
        Object setTivLock(@Path("tier") String paramString, @Body TivLockBody paramTivLockBody, Continuation<? super Response<SetTivLockResponse>> paramContinuation);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account}/networks/{network}/cameras/{camera}/zones")
        Observable<Command> setZones(@Body AdvancedCameraZones paramAdvancedCameraZones, @Path("tier") String paramString, @Path("account") long paramLong1, @Path("network") long paramLong2, @Path("camera") long paramLong3);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v2/network/{network}/sync_module/{type}")
        Observable<Command> startOnboarding(@Body OnboardingStartRequest paramOnboardingStartRequest, @Path("tier") String paramString1, @Path("network") long paramLong, @Path("type") String paramString2);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/accounts/{account}/networks/{network}/owls/add")
        Observable<OwlAddBody> startOwlOnboarding(@Body OnboardingStartRequest paramOnboardingStartRequest, @Path("tier") String paramString, @Path("account") long paramLong1, @Path("network") long paramLong2);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v5/accounts/{account_id}/users/{user_id}/clients/{client_id}/client_verification/pin/verify/")
        Object submitClientVerificationCode(@Path("tier") String paramString, @Path("account_id") long paramLong1, @Path("user_id") long paramLong2, @Path("client_id") long paramLong3, @Body SubmitVerificationRequest paramSubmitVerificationRequest, Continuation<? super Response<SubmitVerificationResponse>> paramContinuation);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v5/accounts/{account_id}/users/{user_id}/clients/{client_id}/phone_number_change/pin/verify")
        Object submitPhoneNumberVerificationCode(@Path("tier") String paramString, @Path("account_id") long paramLong1, @Path("user_id") long paramLong2, @Path("client_id") long paramLong3, @Body SubmitVerificationRequest paramSubmitVerificationRequest, Continuation<? super Response<SubmitVerificationResponse>> paramContinuation);
  
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
        Observable<SendPinResponse> verificationEmail(@Path("tier") String paramString, @Path("account") long paramLong);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/{account}/client/{client}/pin/resend/")
        Observable<SendPinResponse> verificationPinClient(@Path("tier") String paramString, @Path("account") long paramLong1, @Path("client") long paramLong2);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/{account}/pin/resend/")
        Observable<SendPinResponse> verificationPinEmail(@Path("tier") String paramString, @Path("account") long paramLong);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/{account}/pin/verify/")
        Observable<PinVerificationResponse> verifyAccountPIN(@Path("tier") String paramString, @Path("account") long paramLong, @Body VerifyPinBody paramVerifyPinBody);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/{accountId}/client/{clientId}/email_change/pin/verify/")
        Observable<PinVerificationResponse> verifyChangeEmailPinCode(@Path("tier") String paramString, @Path("accountId") long paramLong1, @Path("clientId") long paramLong2, @Body VerifyPinBody paramVerifyPinBody);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/{account}/client/{client}/pin/verify/")
        Observable<PinVerificationResponse> verifyClientPIN(@Path("tier") String paramString, @Path("account") long paramLong1, @Path("client") long paramLong2, @Body VerifyPinBody paramVerifyPinBody);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/{accountId}/client/{clientId}/password_change/pin/verify/")
        Observable<PinVerificationResponse> verifyPasswordChangePinCode(@Path("tier") String paramString, @Path("accountId") long paramLong1, @Path("clientId") long paramLong2, @Body VerifyPinBody paramVerifyPinBody);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v4/account/password_change/pin/verify/")
        Observable<PinVerificationResponse> verifyPasswordChangePinCodeUnauthenticated(@Path("tier") String paramString, @Body VerifyPinBody paramVerifyPinBody);
  
        @POST("https://rest-{tier}.immedia-semi.com/api/v1/account/video_options")
        Observable<Object> videoOptionsSetter(@Body AutoPurgeSetterBody paramAutoPurgeSetterBody, @Path("tier") String paramString);
  
        @Metadata(bv = {1, 0, 3}, d1 = {"\000\024\n\002\030\002\n\002\020\000\n\002\b\002\n\002\020\016\n\002\b\003\b\003\030\0002\0020\001B\007\b\002\006\002\020\002R\016\020\003\032\0020\004X\006\002\n\000R\016\020\005\032\0020\004X\006\002\n\000R\016\020\006\032\0020\004X\006\002\n\000\006\007"}, d2 = {"Lcom/immediasemi/blink/api/retrofit/BlinkWebService$Companion;", "", "()V", "HTTP_APP_BUILD", "", "LOCALE", "TOKEN_AUTH_HEADER", "app_prodRelease"}, k = 1, mv = {1, 4, 0})
            public static final class Companion {
                public static final String HTTP_APP_BUILD = "APP-BUILD";
    
                public static final String LOCALE = "LOCALE";
    
                public static final String TOKEN_AUTH_HEADER = "TOKEN-AUTH";
            }
        }
*/
    }
}
