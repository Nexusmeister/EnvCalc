package de.crystalcase.envcalc.services;

import de.crystalcase.envcalc.entities.Category;
import de.crystalcase.envcalc.repositories.CategoryRepository;
import org.springframework.stereotype.Service;

import javax.annotation.Resource;
import java.util.List;

@Service
public class CategoryService {

    @Resource
    private CategoryRepository categoryRepository;

    public List<Category> getCategories(){
        return categoryRepository.findAll();
    }

}
