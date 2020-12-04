package com.mobeye.mobeye_testing_api.Requests;

public class Device {

    private String deviceId;
    private String deviceName;
    private CommandForDoor commandForDoor;


    public Device() {
        this.deviceId = "deviceId";
        this.deviceName = "deviceName";
        this.commandForDoor = CommandForDoor.OPEN_DOOR;
    }


    public String getDeviceId() {
        return deviceId;
    }

    public void setDeviceId(String deviceId) {
        this.deviceId = deviceId;
    }

    public String getDeviceName() {
        return deviceName;
    }

    public void setDeviceName(String deviceName) {
        this.deviceName = deviceName;
    }

    public CommandForDoor getCommandForDoor() {
        return commandForDoor;
    }

    public void setCommandForDoor(CommandForDoor commandForDoor) {
        this.commandForDoor = commandForDoor;
    }
}
