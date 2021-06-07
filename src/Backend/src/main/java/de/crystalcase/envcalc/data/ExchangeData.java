package de.crystalcase.envcalc.data;

import lombok.Builder;
import lombok.Data;

@Data
@Builder
public class ExchangeData {

    private String name;
    private String unit;
    private Double amount;
    private Boolean input;
}
