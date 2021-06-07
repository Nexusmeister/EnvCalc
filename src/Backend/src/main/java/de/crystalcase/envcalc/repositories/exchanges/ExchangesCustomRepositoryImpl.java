package de.crystalcase.envcalc.repositories.exchanges;

import de.crystalcase.envcalc.entities.Exchange;
import org.elasticsearch.search.aggregations.AggregationBuilders;
import org.springframework.data.elasticsearch.core.ElasticsearchOperations;
import org.springframework.data.elasticsearch.core.SearchHits;
import org.springframework.data.elasticsearch.core.query.NativeSearchQuery;
import org.springframework.data.elasticsearch.core.query.NativeSearchQueryBuilder;

public class ExchangesCustomRepositoryImpl implements ExchangesCustomRepository {
    private final ElasticsearchOperations operations;

    public ExchangesCustomRepositoryImpl(ElasticsearchOperations operations){
        this.operations = operations;
    }



    @Override
    public SearchHits<Exchange> findUniqueExchanges(){
        NativeSearchQuery query = new NativeSearchQueryBuilder()
                .addAggregation(AggregationBuilders.terms("uniq_exchanges")
                        .field("exchanges.flow.name.keyword").size(3000))
                .build();
        query.setMaxResults(0);
        return operations.search(query, Exchange.class);
    }
}
