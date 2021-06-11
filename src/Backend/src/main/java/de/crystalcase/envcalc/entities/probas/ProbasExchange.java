package de.crystalcase.envcalc.entities.probas;

import lombok.Getter;
import lombok.Setter;
import org.springframework.data.annotation.Id;
import org.springframework.data.elasticsearch.annotations.Document;
import org.springframework.data.elasticsearch.annotations.Field;
import org.springframework.data.elasticsearch.annotations.FieldType;

@Getter
@Setter
@Document(indexName = "probas")
public class ProbasExchange {

    @Id
    private Flow flow;
    @Field(type = FieldType.Object, name = "unit")
    private ProbasUnit probasUnit;
    @Field(name = "input")
    private Boolean input;
    @Field(name = "amount")
    private Double amount;

}
