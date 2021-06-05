package de.crystalcase.envcalc.entities;

import lombok.Getter;
import lombok.Setter;
import org.springframework.data.annotation.Id;
import org.springframework.data.elasticsearch.annotations.Document;

import java.util.ArrayList;

@Getter
@Setter
@Document(indexName = "probas")
public class Exchanges {

    @Id
    private String id;
    private String name;
    private ArrayList<String> amountList;
    //TODO Change to Enum
    private ArrayList<String> exchangeTypeList;
    //TODO Change to Enum
    private ArrayList<String> exchangeUnitList;

}
