package com.nvn.services;

import com.nvn.entities.Attendence;
import com.nvn.repository.IAttendenceRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import java.util.List;
import java.util.Optional;

@Service
public class AttendenceServices implements IServices<Attendence, Long>{
    @Autowired
    IAttendenceRepository iAttendenceRepository;

    @Override
    public List<Attendence> getAll() {
        return null;
    }

    @Override
    public Optional<Attendence> findById(Integer id) {
        return Optional.empty();
    }

    @Override
    public void insert(Attendence attendence) {
        iAttendenceRepository.save(attendence);
    }

    @Override
    public void update(Attendence attendence) {

    }

    @Override
    public void delete(Attendence attendence) {

    }

    @Override
    public void deleteById(Long id) {

    }
}
