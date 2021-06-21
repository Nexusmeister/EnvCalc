package de.crystalcase.envcalc.controller;

import de.crystalcase.envcalc.entities.Process;
import de.crystalcase.envcalc.entities.probas.RootEntity;
import de.crystalcase.envcalc.repositories.ProcessRepository;
import de.crystalcase.envcalc.services.RootEntityService;
import org.springframework.data.elasticsearch.core.SearchHits;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

import javax.annotation.Resource;
import java.util.List;

@RestController
public class TestController {

    @Resource
    private RootEntityService rootEntityService;

    @Resource
    private ProcessRepository processRepository;

    @GetMapping(value = "/test")
    @ResponseBody
    private String test(){ return "Test successful"; }

    @GetMapping(value = "/workflow")
    @ResponseBody
    private String workflow(){ return "workflow successful"; }

    @GetMapping(value = "/rawRoot")
    @ResponseBody
    private SearchHits<RootEntity> rawRoot() { return rootEntityService.getRawUniqueRootEntities(); }

    @GetMapping(value = "/rawProcess")
    @ResponseBody
    private List<Process> rawProcess() { return processRepository.findAll(); }

}
