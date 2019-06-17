package itsme;
import com.google.gson.*;
import com.google.gson.annotations.SerializedName;

public class UrlConfig {
    @SerializedName("scopes")
    private final String[] scopes;

    @SerializedName("request_uri")
    private final String requestUri;

    @SerializedName("service_code")
    private final String serviceCode;

    public UrlConfig(String[] scopes, String requestUri, String serviceCode){
        this.scopes = scopes;
        this.requestUri = requestUri;
        this.serviceCode = serviceCode;
    }
}
