package de.crystalcase.envcalc.services;

import de.crystalcase.envcalc.data.ExchangeData;
import de.crystalcase.envcalc.data.RootEntityData;
import de.crystalcase.envcalc.entities.Exchange;
import de.crystalcase.envcalc.entities.RootEntity;
import de.crystalcase.envcalc.enums.RootEntityTypes;
import de.crystalcase.envcalc.repositories.RootEntityRepository;
import org.elasticsearch.search.aggregations.bucket.terms.Terms;
import org.springframework.cache.annotation.Cacheable;
import org.springframework.data.elasticsearch.core.SearchHit;
import org.springframework.data.elasticsearch.core.SearchHits;
import org.springframework.stereotype.Service;

import javax.annotation.Resource;
import java.util.ArrayList;
import java.util.List;

@Service
public class RootEntityService {

    @Resource
    private RootEntityRepository rootEntityRepository;
    @Resource
    private ExchangeService exchangeService;

    @Cacheable(cacheNames = "rootEntities")
    public List<RootEntityData> getUniqueRootEntities(){
        final List<RootEntityData> result = new ArrayList<>();
        SearchHits<RootEntity> rawResult = rootEntityRepository.findAllByType(RootEntityTypes.Process);
        rawResult.stream().forEach(searchHit -> {
            result.add(createData(searchHit.getContent()));
        });
        return result;
    }

    public SearchHits<RootEntity> getRawUniqueRootEntities(){
        return rootEntityRepository.findAllByType(RootEntityTypes.Process);
    }


    private RootEntityData createData(RootEntity rootEntity){
        final ArrayList<ExchangeData> exchangeData = new ArrayList<>();

        for(Exchange exchange : rootEntity.getExchanges())
            exchangeData.add(exchangeService.createData(exchange));

        return RootEntityData.builder()
                .name(rootEntity.getName())
                .exchanges(exchangeData)
                .build();
    }
}
