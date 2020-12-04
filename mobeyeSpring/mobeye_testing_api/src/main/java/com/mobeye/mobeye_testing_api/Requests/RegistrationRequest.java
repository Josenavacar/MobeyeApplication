package com.mobeye.mobeye_testing_api.Requests;


public class RegistrationRequest {
    private String phone_imei;
    private String code;

    public RegistrationRequest(String phone_imei, String code) {
        this.phone_imei = phone_imei;
        this.code = code;
    }

    public String getPhone_imei() {
        return phone_imei;
    }

    public void setPhone_imei(String phone_imei) {
        this.phone_imei = phone_imei;
    }

    public String getCode() {
        return code;
    }

    public void setCode(String code) {
        this.code = code;
    }
}
