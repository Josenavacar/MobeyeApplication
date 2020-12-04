package com.mobeye.mobeye_testing_api.Responses;


public class RegistrationResponse {
    private String private_key;

    public RegistrationResponse() {
        this.private_key = "PRIVATE_KEY";
    }

    public String getPrivate_key() {
        return private_key;
    }

    public void setPrivate_key(String private_key) {
        this.private_key = private_key;
    }
}
