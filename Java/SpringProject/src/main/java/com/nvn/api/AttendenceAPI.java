package com.nvn.api;

import com.nvn.entities.Attendence;
import com.nvn.entities.Lesson;
import com.nvn.repository.IAttendenceRepository;
import com.nvn.services.AttendenceServices;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpRequest;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import javax.servlet.http.HttpServletRequest;
import java.net.InetAddress;
import java.net.UnknownHostException;
import java.sql.Timestamp;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.time.LocalDateTime;
import java.time.ZoneId;
import java.time.format.DateTimeFormatter;
import java.util.Date;
import java.util.List;

@RestController
@RequestMapping("api")
public class AttendenceAPI {

    @Autowired
    AttendenceServices attendenceServices;

    @GetMapping("attendence")
    public ResponseEntity<List<Lesson>> getAttendence(HttpServletRequest request) throws ParseException, UnknownHostException {
        SimpleDateFormat sdf = new SimpleDateFormat("dd.MM.yyyy.HH.mm.ss");
        Date date = new Date();
        System.out.println(new Timestamp(date.getTime()));
        String ipAddress = request.getHeader("X-FORWARDED-FOR");
        if(ipAddress == null){

            ipAddress = request.getRemoteAddr();
        }
        attendenceServices.insert(new Attendence(ipAddress, new Timestamp(date.getTime())));
        return new ResponseEntity<>(HttpStatus.OK);
    }

}
