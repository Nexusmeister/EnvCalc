package de.crystalcase.envcalc.entities;


import lombok.Builder;
import lombok.Getter;
import lombok.Setter;
import org.springframework.data.annotation.Id;
import org.springframework.data.elasticsearch.annotations.Document;

import java.util.List;

@Getter
@Setter
@Builder
@Document(indexName = "envcalc")
public class Product {
    @Id
    private String id;
    private String name;
    private Integer version;
    private List<Process> processes;
    private Boolean deprecated;
}
