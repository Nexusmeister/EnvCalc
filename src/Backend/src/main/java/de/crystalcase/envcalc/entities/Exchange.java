package de.crystalcase.envcalc.entities;

import lombok.Getter;
import lombok.Setter;
import org.springframework.data.annotation.Id;
import org.springframework.data.elasticsearch.annotations.Document;
import org.springframework.data.elasticsearch.annotations.Field;

import java.util.ArrayList;

@Getter
@Setter
@Document(indexName = "probas")
public class Exchange {

    @Id
    private Flow flow;
    private Unit unit;
    @Field(name = "input")
    private Boolean input;
    @Field(name = "amount")
    private Double amount;

}
