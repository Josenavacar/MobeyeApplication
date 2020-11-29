package com.mobeye.mobeye_testing_api.Controllers;

import com.mobeye.mobeye_testing_api.Requests.AlarmRequest;
import com.mobeye.mobeye_testing_api.Requests.AuthorizationRequest;
import com.mobeye.mobeye_testing_api.Requests.DeviceControlRequest;
import com.mobeye.mobeye_testing_api.Responses.AlarmResponse;
import com.mobeye.mobeye_testing_api.Responses.AuthorizationResponse;
import com.mobeye.mobeye_testing_api.Responses.DeviceControlResponse;
import com.mobeye.mobeye_testing_api.Responses.RegistrationResponse;
import org.springframework.web.bind.annotation.*;

import com.mobeye.mobeye_testing_api.Requests.RegistrationRequest;

@CrossOrigin(origins = "http://localhost:44349")
@RestController
@RequestMapping
public class Controllers {

    public Controllers() {
    }

    @PostMapping("/registration")
    public RegistrationResponse testRegistration(@RequestBody RegistrationRequest registrationRequest){
        RegistrationResponse registrationResponse = new RegistrationResponse();
        return registrationResponse;
    }

    @PostMapping("/api/device_control")
    public DeviceControlResponse testDeviceControl(@RequestBody DeviceControlRequest deviceControlRequest){
        DeviceControlResponse deviceControlResponse = new DeviceControlResponse();
        return deviceControlResponse;

    }

    @PostMapping("/api/auth")
    public AuthorizationResponse testAuthorization(@RequestBody AuthorizationRequest authorizationRequest){
        AuthorizationResponse authorizationResponse = new AuthorizationResponse();
        return authorizationResponse;
    }

    @PostMapping("/api/alarm")
    public Boolean testPostAlarm(@RequestBody AlarmRequest alarmRequest){
        return true;
    }

    @GetMapping("/api/alarm")
    public AlarmResponse testGetAlarm(){
        return new AlarmResponse();
    }


    @GetMapping("/test")
    public String test(){
        return "ok";
    }
}
