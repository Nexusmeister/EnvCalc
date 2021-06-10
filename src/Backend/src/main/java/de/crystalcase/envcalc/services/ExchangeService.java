package de.crystalcase.envcalc.services;

import de.crystalcase.envcalc.data.ExchangeData;
import de.crystalcase.envcalc.entities.probas.ProbasExchange;
import de.crystalcase.envcalc.repositories.probas.ProbasExchangeRepository;
import org.elasticsearch.search.aggregations.bucket.terms.Terms;
import org.springframework.data.elasticsearch.core.SearchHits;
import org.springframework.stereotype.Service;

import javax.annotation.Resource;
import java.util.ArrayList;
import java.util.List;

@Service
public class ExchangeService {

    @Resource
    private ProbasExchangeRepository probasExchangeRepository;

    public List<String> getUniqueExchanges(){
        final SearchHits<ProbasExchange> rawResult = probasExchangeRepository.findUniqueExchanges();
        final List<String> exchangeData = new ArrayList<>();
        for(Terms.Bucket bucket : ((Terms)rawResult.getAggregations().asList().get(0)).getBuckets())
            exchangeData.add((String)bucket.getKey());

        return exchangeData;
    }

    public List<String> getUniqueUnits(){
        final SearchHits<ProbasExchange> rawResult = probasExchangeRepository.findUniqueUnits();
        final List<String> units = new ArrayList<>();
        for(Terms.Bucket bucket : ((Terms)rawResult.getAggregations().asList().get(0)).getBuckets())
            units.add((String)bucket.getKey());
        return units;
    }

    public ExchangeData createData(ProbasExchange probasExchange){
        return ExchangeData.builder()
                .name(probasExchange.getFlow().getName())
                .unit(probasExchange.getProbasUnit().getName())
                .amount(probasExchange.getAmount())
                .input(probasExchange.getInput())
                .build();
    }
}
