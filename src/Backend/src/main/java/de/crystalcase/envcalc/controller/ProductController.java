package de.crystalcase.envcalc.controller;

import de.crystalcase.envcalc.entities.Product;
import de.crystalcase.envcalc.services.ProductService;
import org.springframework.web.bind.annotation.*;

import javax.annotation.Resource;
import java.util.List;

@RestController
public class ProductController {

    @Resource
    private ProductService productService;

    @GetMapping(value = "/products")
    @ResponseBody
    public List<Product> getAll(){
        return productService.getAll();
    }

    @PostMapping(value = "/product")
    @ResponseBody
    public boolean createUpdate(@RequestBody Product product){
        return productService.createUpdate(product);
    }

}
