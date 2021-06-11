package de.crystalcase.envcalc.services;

import de.crystalcase.envcalc.entities.Product;
import de.crystalcase.envcalc.repositories.ProductRepository;
import org.joda.time.DateTime;
import org.joda.time.Instant;
import org.springframework.cache.annotation.CacheEvict;
import org.springframework.cache.annotation.Cacheable;
import org.springframework.stereotype.Service;

import javax.annotation.Resource;
import java.util.List;
import java.util.Optional;

@Service
public class ProductService {
    @Resource
    private ProductRepository productRepository;


    @Cacheable(cacheNames = "products")
    public List<Product> getAll(){
        return productRepository.findAll();
    }

    @CacheEvict(cacheNames = "products")
    public boolean createUpdate(Product data) {
        if (data == null || data.getName() == null)
            return false;

        final Optional<Product> result = productRepository.findByName(data.getName());
        int currentVersion = 0;
        if (result.isPresent()) {
            final Product oldProduct = result.get();
            oldProduct.setDeprecated(true);
            currentVersion = oldProduct.getVersion();
            productRepository.save(oldProduct);
        }
        final Product newProduct = Product.builder()
                .deprecated(false)
                .name(data.getName())
                .processes(data.getProcesses())
                .version(currentVersion + 1)
                .created(new Instant().getMillis())
                .build();
        productRepository.save(newProduct);

        return true;
    }

}
