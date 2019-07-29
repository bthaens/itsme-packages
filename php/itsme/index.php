<?php
$ffi = FFI::cdef("

extern char* Init(char* p0);

struct Response {
	char* data;
	char* error;
};

extern struct Response GetAuthenticationURL(char* p0);

extern struct Response GetUserDetails(char* p0);",
"Path to itsme_lib.so");

class ErrorMessage
{
    public function __construct ($json)
    {
        $error = json_decode($json, TRUE);
        $this->message = 
            isset($error['message']) ? $error['message'] : 'Could not parse error object';
    }
}

class User
{
    public function __construct ($json)
    {
        $user = json_decode($json, TRUE);
        $this->sub = isset($user['sub']) ? $user['sub'] : '';
        $this->aud = isset($user['aud']) ? $user['aud'] : '';
        $this->birthdate = isset($user['birthdate']) ? $user['birthdate'] : '';
        $this->gender = isset($user['gender']) ? $user['gender'] : '';
        $this->name = isset($user['name']) ? $user['name'] : '';
        $this->iss = isset($user['iss']) ? $user['iss'] : '';
        $this->phone_number_verified = isset($user['phone_number_verified']) ? $user['phone_number_verified'] : '';
        $this->phone_number = isset($user['phone_number']) ? $user['phone_number'] : '';
        $this->given_name = isset($user['given_name']) ? $user['given_name'] : '';
        $this->family_name = isset($user['family_name']) ? $user['family_name'] : '';
        $this->locale = isset($user['locale']) ? $user['locale'] : '';
        $this->email = isset($user['email']) ? $user['email'] : '';
        $this->address = isset($user['parsed_address']) ? new Address($user['parsed_address']) : '';
    }
}

class Address{
    public function __construct ($json)
    {
        $address = $json;
        $this->country = isset($address['country']) ? $address['country'] : '';
        $this->street_address = isset($address['street_address']) ? $address['street_address'] : '';
        $this->locality = isset($address['locality']) ? $address['locality'] : '';
        $this->postal_code = isset($address['postal_code']) ? $address['postal_code'] : '';
    }
}

class ItsmeSettings { 
    public function __construct ($client_id, $redirect_uri, $private_jwk_set)
    {
        $this->client_id = $client_id;
        $this->redirect_uri = $redirect_uri;
        $this->private_jwk_set = $private_jwk_set; 
    }
}

class UrlConfiguration{
    public function __construct ($scopes, $service_code, $request_uri)
    {
        $this->scope = $scopes;
        $this->request_uri = $request_uri;
        $this->service_code = $service_code;
    }
}

class Client
{
    public function __construct ($settings)
    {
        global $ffi;
        # Initialize the library
        $settingsJson = json_encode($settings);
        $response = $ffi->Init($settingsJson);
        if ($response){
            $error = new ErrorMessage(FFI::string($response));
            throw new Exception($error->message);
        }
    }

    public function GetUserDetails ($code)
    {
        global $ffi;
        $response = $ffi->GetUserDetails($code);
        if ($response->error != NULL){
            $error = new ErrorMessage(FFI::string($response->error));
            throw new Exception($error->message);
        }
        return new User(FFI::string($response->data));
    }

    public function GetAuthenticationUrl ($config)
    {
        global $ffi;
        $config_json = json_encode($config);
        $response = $ffi->GetAuthenticationURL($config_json);
        if ($response->error != NULL){
            $error = new ErrorMessage(FFI::string($response->error));
            throw new Exception($error->message);
        }
        return FFI::string($response->data);
    }

}

?>
