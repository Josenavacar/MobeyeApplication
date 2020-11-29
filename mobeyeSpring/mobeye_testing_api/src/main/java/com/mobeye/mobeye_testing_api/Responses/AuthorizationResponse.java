package com.mobeye.mobeye_testing_api.Responses;

import com.mobeye.mobeye_testing_api.Requests.Device;
import com.mobeye.mobeye_testing_api.Requests.UserRole;

import java.util.ArrayList;
import java.util.List;

public class AuthorizationResponse {

    private UserRole userRole;
    private List<Device> devices;

    public AuthorizationResponse() {
        this.userRole = UserRole.ACCOUNT;
        devices = new ArrayList<>();
        devices.add(new Device());
    }

    public UserRole getUserRole() {
        return userRole;
    }

    public void setUserRole(UserRole userRole) {
        this.userRole = userRole;
    }

    public List<Device> getDevices() {
        return devices;
    }

    public void setDevices(List<Device> devices) {
        this.devices = devices;
    }
}
