package com.nvn.repository;

import org.springframework.data.jpa.repository.JpaRepository;
import org.springframework.stereotype.Repository;

import com.nvn.entities.Category;

@Repository
public interface ICategoryRepository extends JpaRepository<Category, Integer>{

}
