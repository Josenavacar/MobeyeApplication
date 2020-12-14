package com.mobeye.mobeye_testing_api.Requests;

public class DeviceControlRequest {
    private String phone_imei;
    private String deviceId;
    private String private_key;
    private CommandForDoor commandForDoor;

    public DeviceControlRequest(String phone_imei, String deviceId, String private_key, CommandForDoor commandForDoor) {
        this.phone_imei = phone_imei;
        this.deviceId = deviceId;
        this.private_key = private_key;
        this.commandForDoor = commandForDoor;
    }

    public DeviceControlRequest(){

    }

    public String getPhone_imei() {
        return phone_imei;
    }

    public void setPhone_imei(String phone_imei) {
        this.phone_imei = phone_imei;
    }

    public String getDeviceId() {
        return deviceId;
    }

    public void setDeviceId(String deviceId) {
        this.deviceId = deviceId;
    }

    public String getPrivate_key() {
        return private_key;
    }

    public void setPrivate_key(String private_key) {
        this.private_key = private_key;
    }

    public CommandForDoor getCommandForDoor() {
        return commandForDoor;
    }

    public void setCommandForDoor(CommandForDoor commandForDoor) {
        this.commandForDoor = commandForDoor;
    }
}
