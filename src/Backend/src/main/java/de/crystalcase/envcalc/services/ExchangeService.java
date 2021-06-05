package de.crystalcase.envcalc.services;

import de.crystalcase.envcalc.entities.Exchanges;
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
        final SearchHits<Exchanges> rawResult = exchangesRepository.findByNameWithUniqueExchanges();
        final List<String> exchangeData = new ArrayList<>();
        for(Terms.Bucket bucket : ((Terms)rawResult.getAggregations().asList().get(0)).getBuckets())
            exchangeData.add((String)bucket.getKey());

        return exchangeData;
    }
}
