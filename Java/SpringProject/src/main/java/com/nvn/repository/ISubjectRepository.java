package com.nvn.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.nvn.entities.Subject;

@Repository
public interface ISubjectRepository extends JpaRepository<Subject, Integer>{
}
