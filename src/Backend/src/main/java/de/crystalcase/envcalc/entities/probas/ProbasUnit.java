package de.crystalcase.envcalc.entities.probas;

import lombok.Getter;
import lombok.Setter;
import org.springframework.data.annotation.Id;
import org.springframework.data.elasticsearch.annotations.Document;

@Getter
@Setter
@Document(indexName = "probas")
public class ProbasUnit {
    @Id
    private String name;
}
