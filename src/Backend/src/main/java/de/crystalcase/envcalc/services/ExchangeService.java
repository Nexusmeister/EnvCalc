package de.crystalcase.envcalc.services;

import de.crystalcase.envcalc.data.ExchangeData;
import de.crystalcase.envcalc.entities.Exchange;
import de.crystalcase.envcalc.repositories.ExchangesRepository;
import org.elasticsearch.search.aggregations.bucket.terms.Terms;
import org.springframework.data.elasticsearch.core.SearchHits;
import org.springframework.stereotype.Service;

import javax.annotation.Resource;
import java.util.ArrayList;
import java.util.List;

@Service
public class ExchangeService {

    @Resource
    private ExchangesRepository exchangesRepository;

    public List<String> getUniqueExchanges(){
        final SearchHits<Exchange> rawResult = exchangesRepository.findUniqueExchanges();
        final List<String> exchangeData = new ArrayList<>();
        for(Terms.Bucket bucket : ((Terms)rawResult.getAggregations().asList().get(0)).getBuckets())
            exchangeData.add((String)bucket.getKey());

        return exchangeData;
    }

    public List<String> getUniqueUnits(){
        final SearchHits<Exchange> rawResult = exchangesRepository.findUniqueUnits();
        final List<String> units = new ArrayList<>();
        for(Terms.Bucket bucket : ((Terms)rawResult.getAggregations().asList().get(0)).getBuckets())
            units.add((String)bucket.getKey());
        return units;
    }

    public ExchangeData createData(Exchange exchange){
        return ExchangeData.builder()
                .name(exchange.getFlow().getName())
                .unit(exchange.getUnit().getName())
                .amount(exchange.getAmount())
                .input(exchange.getInput())
                .build();
    }
}
