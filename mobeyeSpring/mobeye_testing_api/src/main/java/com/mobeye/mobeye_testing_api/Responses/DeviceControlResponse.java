package com.mobeye.mobeye_testing_api.Responses;

public class DeviceControlResponse {
    private boolean succsess;

    public DeviceControlResponse() {
        this.succsess = true;
    }

    public boolean isSuccsess() {
        return succsess;
    }

    public void setSuccsess(boolean succsess) {
        this.succsess = succsess;
    }
}
