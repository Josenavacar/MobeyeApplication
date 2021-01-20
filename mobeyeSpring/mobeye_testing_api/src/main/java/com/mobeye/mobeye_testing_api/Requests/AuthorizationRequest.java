package com.mobeye.mobeye_testing_api.Requests;

public class AuthorizationRequest {
    private String phoneImei;
    private String private_key;

    public AuthorizationRequest(String phoneImei, String private_key) {
        this.phoneImei = phoneImei;
        this.private_key = private_key;
    }

    public String getPhoneImei() {
        return phoneImei;
    }

    public void setPhoneImei(String phoneImei) {
        this.phoneImei = phoneImei;
    }

    public String getPrivate_key() {
        return private_key;
    }

    public void setPrivate_key(String private_key) {
        this.private_key = private_key;
    }
}
