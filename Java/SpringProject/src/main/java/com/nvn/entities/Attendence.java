package com.nvn.entities;

import javax.persistence.*;
import java.sql.Timestamp;

@Entity
@Table(name = "Attendence")
public class Attendence {

    private String ip;
    private Timestamp time;
    private int id;

    public Attendence(String ip, Timestamp time) {
        this.ip = ip;
        this.time = time;
    }

    public Attendence(int id, String ip, Timestamp time) {
        this.ip = ip;
        this.time = time;
        this.id = id;
    }

    @Id
    @GeneratedValue(strategy=GenerationType.IDENTITY)
    @Column(name = "id")
    public int getId() {
        return id;
    }

    public void setId(int id) {
        this.id = id;
    }

    @Column(name = "ip")
    public String getIp() {
        return ip;
    }

    public void setIp(String ip) {
        this.ip = ip;
    }

    @Column(name = "time")
    public Timestamp getTime() {
        return time;
    }

    public void setTime(Timestamp time) {
        this.time = time;
    }

}
