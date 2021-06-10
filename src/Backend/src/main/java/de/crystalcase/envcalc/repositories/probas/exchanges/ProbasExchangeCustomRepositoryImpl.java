package de.crystalcase.envcalc.repositories.probas.exchanges;

import de.crystalcase.envcalc.entities.probas.ProbasExchange;
import org.elasticsearch.search.aggregations.AggregationBuilders;
import org.springframework.data.elasticsearch.core.ElasticsearchOperations;
import org.springframework.data.elasticsearch.core.SearchHits;
import org.springframework.data.elasticsearch.core.query.NativeSearchQuery;
import org.springframework.data.elasticsearch.core.query.NativeSearchQueryBuilder;

public class ProbasExchangeCustomRepositoryImpl implements ProbasExchangeCustomRepository {
    private final ElasticsearchOperations operations;

    public ProbasExchangeCustomRepositoryImpl(ElasticsearchOperations operations){
        this.operations = operations;
    }



    @Override
    public SearchHits<ProbasExchange> findUniqueExchanges(){
        NativeSearchQuery query = new NativeSearchQueryBuilder()
                .addAggregation(AggregationBuilders.terms("uniq_exchanges")
                        .field("exchanges.flow.name.keyword").size(3000))
                .build();
        query.setMaxResults(0);
        return operations.search(query, ProbasExchange.class);
    }

    @Override
    public SearchHits<ProbasExchange> findUniqueUnits() {
        NativeSearchQuery query = new NativeSearchQueryBuilder()
                .addAggregation(AggregationBuilders.terms("uniq_units")
                        .field("exchanges.unit.name").size(3000))
                .build();
        query.setMaxResults(0);
        return operations.search(query, ProbasExchange.class);
    }

}
