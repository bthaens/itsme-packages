package itsme;
import com.google.gson.*;
import com.google.gson.annotations.SerializedName;

public class Settings {
    @SerializedName("client_id")
    private final String clientId;

    @SerializedName("redirect_uri")
    private final String redirectUri;

    @SerializedName("private_jwk_set")
    private final String privateKey;

    public Settings(String clientId, String redirectUri, String privateKey){
        this.clientId = clientId;
        this.redirectUri = redirectUri;
        this.privateKey = privateKey;
    }
}
