package itsme;
import com.google.gson.annotations.SerializedName;

public class Address {
    public String country;
    public String locality;

    @SerializedName("street_address")
    public String streetAddress;

    @SerializedName("postal_code")
    public String postalCode;
}
