package com.nvn.repository;

import com.nvn.entities.Attendence;
import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

@Repository
public interface IAttendenceRepository extends JpaRepository<Attendence, String> {
}
