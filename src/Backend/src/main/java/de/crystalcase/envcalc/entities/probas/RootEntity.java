package de.crystalcase.envcalc.entities.probas;

import de.crystalcase.envcalc.enums.RootEntityTypes;
import lombok.Getter;
import lombok.Setter;
import org.springframework.data.annotation.Id;
import org.springframework.data.elasticsearch.annotations.Document;
import org.springframework.data.elasticsearch.annotations.Field;
import org.springframework.data.elasticsearch.annotations.FieldType;

import java.util.List;

@Document(indexName = "probas")
@Getter
@Setter
public class RootEntity {

    @Id
    private String id;
    private String name;
    @Field(type = FieldType.Text, name = "type")
    private RootEntityTypes type;
    @Field(type = FieldType.Object, name = "exchanges")
    private List<ProbasExchange> probasExchanges;

}
