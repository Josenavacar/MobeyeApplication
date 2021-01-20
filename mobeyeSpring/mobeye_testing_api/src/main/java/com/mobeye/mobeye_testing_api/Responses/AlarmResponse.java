package com.mobeye.mobeye_testing_api.Responses;

import java.util.ArrayList;
import java.util.Date;
import java.util.List;

public class AlarmResponse {
    private String device_name;
    private String device_location;
    private String alarm_message;
    private String alarm_value;
    private String alarm_reset;
    private Date date_time;
    private String unique_message_id;
    private String priority;
    private Boolean escalation;
    private List<String> imeis;

    public AlarmResponse() {
        this.device_name = "deviceName";
        this.device_location = "device_location";
        this.alarm_message = "alarm_message";
        this.alarm_value = "alarm_value";
        this.alarm_reset = "alarm_reset";
        this.date_time = new Date();
        this.unique_message_id = "unique_message_id";
        this.priority = "alarm";
        this.escalation = true;
        this.imeis = new ArrayList<>();
        imeis.add("imei1");
        imeis.add("imei2");
    }

    public String getDevice_name() {
        return device_name;
    }

    public void setDevice_name(String device_name) {
        this.device_name = device_name;
    }

    public String getDevice_location() {
        return device_location;
    }

    public void setDevice_location(String device_location) {
        this.device_location = device_location;
    }

    public String getAlarm_message() {
        return alarm_message;
    }

    public void setAlarm_message(String alarm_message) {
        this.alarm_message = alarm_message;
    }

    public String getAlarm_value() {
        return alarm_value;
    }

    public void setAlarm_value(String alarm_value) {
        this.alarm_value = alarm_value;
    }

    public String getAlarm_reset() {
        return alarm_reset;
    }

    public void setAlarm_reset(String alarm_reset) {
        this.alarm_reset = alarm_reset;
    }

    public Date getDate_time() {
        return date_time;
    }

    public void setDate_time(Date date_time) {
        this.date_time = date_time;
    }

    public String getUnique_message_id() {
        return unique_message_id;
    }

    public void setUnique_message_id(String unique_message_id) {
        this.unique_message_id = unique_message_id;
    }

    public String getPriority() {
        return priority;
    }

    public void setPriority(String priority) {
        this.priority = priority;
    }

    public Boolean getEscalation() {
        return escalation;
    }

    public void setEscalation(Boolean escalation) {
        this.escalation = escalation;
    }

    public List<String> getImeis() {
        return imeis;
    }

    public void setImeis(List<String> imeis) {
        this.imeis = imeis;
    }
}
