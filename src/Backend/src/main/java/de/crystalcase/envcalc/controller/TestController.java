package de.crystalcase.envcalc.controller;

import de.crystalcase.envcalc.entities.Category;
import de.crystalcase.envcalc.entities.RootEntity;
import de.crystalcase.envcalc.repositories.ExchangesRepository;
import de.crystalcase.envcalc.services.CategoryService;
import de.crystalcase.envcalc.services.RootEntityService;
import org.springframework.data.elasticsearch.core.SearchHits;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

import javax.annotation.Resource;
import java.util.List;

@RestController
public class TestController {

    @Resource
    private CategoryService categoryService;
    @Resource
    private ExchangesRepository exchangesRepository;
    @Resource
    private RootEntityService rootEntityService;

    @PostMapping(value = "/categories")
    @ResponseBody
    private List<Category> getAll(){
        return categoryService.getCategories();
    }


    @GetMapping(value = "/test")
    @ResponseBody
    private String test(){ return "Test successful"; }

    @GetMapping(value = "/workflow")
    @ResponseBody
    private String workflow(){ return "workflow successful"; }

    @GetMapping(value = "rawRoot")
    @ResponseBody
    private SearchHits<RootEntity> rawRoot() { return rootEntityService.getRawUniqueRootEntities(); }

}
