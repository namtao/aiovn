package com.nvn.api;

import com.nvn.entities.Attendence;
import com.nvn.entities.Lesson;
import com.nvn.services.AttendenceServices;
import com.nvn.services.LessonService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.factory.annotation.Qualifier;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

import java.net.InetAddress;
import java.net.UnknownHostException;
import java.text.ParseException;
import java.time.LocalDateTime;
import java.time.ZoneId;
import java.time.format.DateTimeFormatter;
import java.util.Date;
import java.util.List;

@RestController
@RequestMapping("api")
public class LessonAPI {
    @Qualifier("lessonService")
    @Autowired
    LessonService lessonService;

    @Autowired
    AttendenceServices attendenceServices;

    @GetMapping("lesson")
    public ResponseEntity<List<Lesson>> getAllLesson() throws ParseException {
        List<Lesson> list=lessonService.getAll();
        return new ResponseEntity<List<Lesson>>(lessonService.getAll(), HttpStatus.OK);
    }
}
