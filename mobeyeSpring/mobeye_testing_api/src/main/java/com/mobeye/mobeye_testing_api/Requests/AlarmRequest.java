package com.mobeye.mobeye_testing_api.Requests;

public class AlarmRequest {
    public String phone_imei;
    public String unique_message_id;
    public String response;
    public String private_key;

    public AlarmRequest() {
        this.phone_imei = "PhoneImei";
        this.unique_message_id = "UniqueMessageId";
        this.response = "Confirmed";
        this.private_key = "PrivateKey";
    }


    public String getPhone_imei() {
        return phone_imei;
    }

    public void setPhone_imei(String phone_imei) {
        this.phone_imei = phone_imei;
    }

    public String getUnique_message_id() {
        return unique_message_id;
    }

    public void setUnique_message_id(String unique_message_id) {
        this.unique_message_id = unique_message_id;
    }

    public String getResponse() {
        return response;
    }

    public void setResponse(String response) {
        this.response = response;
    }

    public String getPrivate_key() {
        return private_key;
    }

    public void setPrivate_key(String private_key) {
        this.private_key = private_key;
    }
}
