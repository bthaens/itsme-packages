package itsme;

import java.util.Date;
import com.google.gson.annotations.SerializedName;

public class User {
    @SerializedName("phone_number_verified")
    public Boolean phoneNumberVerified;

    @SerializedName("phone_number")
    public String phoneNumber;

    @SerializedName("given_name")
    public String givenName;

    @SerializedName("family_name")
    public String familyName;

    @SerializedName("parsed_address")
    public Address address;

    public String sub;
    public String aud;
    public Date birthdate;
    public String gender;
    public String name;
    public String iss;
    public String locale;
    public String email;
}
