package de.crystalcase.envcalc.entities;

import lombok.Getter;
import lombok.Setter;
import org.springframework.data.annotation.Id;
import org.springframework.data.elasticsearch.annotations.Document;

@Getter
@Setter
@Document(indexName = "envcalc")
public class Exchange {

    @Id
    private String id;
    private String name;
    private Double amount;
    private String unit;

}
