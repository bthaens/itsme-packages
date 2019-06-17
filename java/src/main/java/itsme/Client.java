package itsme;

import com.sun.jna.*;
import java.util.*;
import com.google.gson.*;


public class Client {
    private final Settings settings;
    private final ItsmeLib itsme;

    public interface ItsmeLib extends Library {
        public Response GetAuthenticationURL(String s);
        public Response GetUserDetails(String s);
        public String Init(String s);
    }

    public Client(Settings settings){
        this.settings = settings;
        this.itsme = this.getItsmeLib();
        Gson gson = new GsonBuilder().create();
        String result = this.itsme.Init(gson.toJson(settings));
    }

    public String getAuthenticationUrl(UrlConfig config){
        Gson gson = new GsonBuilder().create();
        String result = this.itsme.Init(gson.toJson(settings));
        Response response = this.itsme.GetAuthenticationURL(gson.toJson(config));
        if(response.error != null){
            throw new RuntimeException(response.error);
        }
        return response.data;
    }

    public User getUserDetails(String authorizationCode){
        Response response = this.itsme.GetUserDetails(authorizationCode);
        if(response.error != null){
            throw new RuntimeException(response.error);
        }
        String user_json = response.data;
        JsonObject user_data = new JsonParser().parse(user_json).getAsJsonObject();
        User user = new Gson().fromJson(user_json, User.class);
        return user;
    }

    private ItsmeLib getItsmeLib(){
        OsCheck.OSType ostype=OsCheck.getOperatingSystemType();
        String extension = "";
        switch (ostype) {
            case Windows:
                extension = "dll";
                break;
            case MacOS:
                extension = "dylib";
                break;
            case Linux:
                extension = "so";
                break;
            case Other:
                extension = "so";
                break;
        }

        return (ItsmeLib) Native.loadLibrary("libs/itsme_lib."+extension, ItsmeLib.class);
    }
}
