package de.crystalcase.envcalc.controller;

import de.crystalcase.envcalc.services.ExchangeService;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.bind.annotation.RestController;

import javax.annotation.Resource;
import java.util.List;

@RestController
public class ExchangesController {

    @Resource
    private ExchangeService exchangeService;

    @GetMapping(value = "/exchanges")
    @ResponseBody
    private List<String> getUniqueExchanges(){
        return exchangeService.getUniqueExchanges();
    }

    @GetMapping(value = "/units")
    @ResponseBody
    private List<String> getUniqueUnits(){
        return exchangeService.getUniqueUnits();
    }

}
