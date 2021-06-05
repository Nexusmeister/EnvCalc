package de.crystalcase.envcalc.repositories;

import de.crystalcase.envcalc.entities.Category;
import org.springframework.data.repository.Repository;

import java.util.List;

public interface CategoryRepository extends Repository<Category, String> {

    List<Category> findAll();
}
