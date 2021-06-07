package de.crystalcase.envcalc.controller;

import de.crystalcase.envcalc.data.RootEntityData;
import de.crystalcase.envcalc.services.RootEntityService;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

import javax.annotation.Resource;
import java.util.List;

@RestController
public class RootEntityController {

    @Resource
    private RootEntityService rootService;

    @GetMapping(value = "/rootEntity")
    @ResponseBody
    public List<RootEntityData> getUniqueRootEntities(){
        return rootService.getUniqueRootEntities();
    }
}
