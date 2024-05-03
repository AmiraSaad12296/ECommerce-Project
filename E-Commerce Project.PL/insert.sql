INSERT INTO Category (CatName, CatImage, IsActive, CreatedDate) 
VALUES ('Telectronic', 'telectronic_image.jpg', 1, CURRENT_TIMESTAMP);


INSERT INTO SubCategory (SubCatName, IsActive, CreatedDate, CategoryId) 
VALUES ('Mobiles', 1, CURRENT_TIMESTAMP, 1);


INSERT INTO SubCategory (SubCatName, IsActive, CreatedDate, CategoryId) 
VALUES (' Accessories', 1, CURRENT_TIMESTAMP, 1);


INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Mobile Phone X', 'Latest model', 'This mobile phone comes with advanced features.', 'Includes charger and earphones', 'Black', '6 inches', 699.99, 100, 'Tech Corp', 1, 1, 0, 0, 1, CURRENT_TIMESTAMP);

INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Mobile Phone Y', 'Flagship model', 'High-performance mobile phone for multitasking.', 'Available in multiple colors.', 'Silver', '6.5 inches', 799.99, 50, 'Gadget Enterprises', 1, 1, 0, 0, 1, CURRENT_TIMESTAMP);

INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Wireless Earphones', 'Bluetooth earbuds', 'Enjoy music on the go with these wireless earphones.', 'Long-lasting battery life', 'White', 'One size', 49.99, 200, 'SoundTech', 1, 2, 0, 0, 1, CURRENT_TIMESTAMP);

INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Phone Case', 'Protective cover', 'Durable phone case for reliable protection against drops and scratches.', 'Available in various designs.', 'Black', 'For iPhone 12', 19.99, 150, 'Guardian Cases', 1, 2, 0, 0, 1, CURRENT_TIMESTAMP);


INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Smartphone Z', 'Budget-friendly option', 'A reliable smartphone with essential features.', 'Comes with a fast charger.', 'Blue', '5.5 inches', 299.99, 80, 'TechCo', 1, 1, 0, 0, 1, CURRENT_TIMESTAMP);

INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Android Phone A', 'High-resolution display', 'Android phone with a large screen for multimedia.', 'Expandable storage up to 128GB.', 'Gold', '6.2 inches', 499.99, 60, 'GizmoTech', 1, 1, 0, 0, 1, CURRENT_TIMESTAMP);

INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Bluetooth Speaker', 'Portable audio', 'Enjoy music anywhere with this compact Bluetooth speaker.', 'Water-resistant design.', 'Red', 'Small', 79.99, 100, 'SoundWave', 1, 2, 0, 0, 1, CURRENT_TIMESTAMP);

INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Car Phone Holder', 'Hands-free solution', 'Securely mount your phone in the car for safe navigation.', 'Adjustable grip fits most smartphones.', 'Black', 'Universal', 29.99, 120, 'DriveSafe', 1, 2, 0, 0, 1, CURRENT_TIMESTAMP);


INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Flagship Smartphone', 'Top-tier performance', 'Experience cutting-edge technology with this flagship smartphone.', 'Dual-camera setup for stunning photos.', 'Black', '6.7 inches', 899.99, 40, 'Tech Giants', 1, 1, 0, 0, 1, CURRENT_TIMESTAMP);

INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Compact Smartphone', 'Pocket-sized design', 'Small yet powerful smartphone for users on the go.', 'Fast charging support for convenience.', 'White', '5 inches', 399.99, 70, 'Tech Innovations', 1, 1, 0, 0, 1, CURRENT_TIMESTAMP);

INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Wireless Charging Pad', 'Convenient charging solution', 'Charge your compatible devices wirelessly with this sleek charging pad.', 'Compatible with Qi-enabled smartphones.', 'Black', 'One size', 39.99, 90, 'PowerTech', 1, 2, 0, 0, 1, CURRENT_TIMESTAMP);

INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Screen Protector', 'Protective film', 'High-quality screen protector to shield your phone from scratches and fingerprints.', 'Bubble-free installation.', 'Transparent', 'For iPhone 13', 9.99, 200, 'GuardianTech', 1, 2, 0, 0, 1, CURRENT_TIMESTAMP);


INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Premium Smartphone', 'Luxury design', 'Elegant smartphone with premium materials and craftsmanship.', 'Large AMOLED display for vibrant visuals.', 'Silver', '6.5 inches', 1099.99, 30, 'LuxuryTech', 1, 1, 0, 0, 1, CURRENT_TIMESTAMP);

INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Budget Smartphone', 'Affordable option', 'Basic smartphone with essential features at an unbeatable price.', 'Available in various colors.', 'Blue', '5 inches', 199.99, 50, 'BudgetGadgets', 1, 1, 0, 0, 1, CURRENT_TIMESTAMP);


INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Wireless Headphones', 'Hi-Fi audio experience', 'Immerse yourself in music with these high-quality wireless headphones.', 'Noise-canceling technology for uninterrupted listening.', 'Black', 'One size', 129.99, 80, 'AudioTech', 1, 2, 0, 0, 1, CURRENT_TIMESTAMP);

INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Smartwatch', 'Fitness tracking', 'Stay active and monitor your health with this feature-packed smartwatch.', 'Water-resistant design suitable for outdoor activities.', 'Rose Gold', 'One size', 199.99, 60, 'FitTech', 1, 2, 0, 0, 1, CURRENT_TIMESTAMP);


INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Pro Smartphone', 'Professional grade', 'A powerful smartphone designed for productivity and performance.', 'Advanced camera features for professional photography.', 'Graphite', '6.8 inches', 1299.99, 20, 'ProTech', 1, 1, 0, 0, 1, CURRENT_TIMESTAMP);

INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Compact Smartphone', 'Pocket-friendly design', 'Slim and compact smartphone with all the essential features.', 'Ideal for users who prefer smaller devices.', 'White', '5.2 inches', 349.99, 40, 'CompactTech', 1, 1, 0, 0, 1, CURRENT_TIMESTAMP);


INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Wireless Earbuds', 'True wireless freedom', 'Experience seamless audio with these lightweight and comfortable earbuds.', 'Up to 20 hours of battery life with charging case.', 'Midnight Black', 'One size', 89.99, 60, 'AudioTech', 1, 2, 0, 0, 1, CURRENT_TIMESTAMP);

INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Car Charger', 'Fast charging on the go', 'Charge your devices quickly while driving with this compact car charger.', 'Multiple USB ports for simultaneous charging.', 'Black', 'One size', 19.99, 80, 'DriveTech', 1, 2, 0, 0, 1, CURRENT_TIMESTAMP);

INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Premium Smartphone', 'Exquisite design', 'Experience luxury with this premium smartphone crafted from premium materials.', 'High-resolution display for immersive viewing.', 'Gold', '6.5 inches', 999.99, 15, 'LuxuryGadgets', 1, 1, 0, 0, 1, CURRENT_TIMESTAMP);

INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Business Smartphone', 'Tailored for professionals', 'Stay connected and productive with this business-oriented smartphone.', 'Enhanced security features for sensitive data protection.', 'Black', '6 inches', 799.99, 25, 'BizTech', 1, 1, 0, 0, 1, CURRENT_TIMESTAMP);
INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Power Bank', 'Portable charging solution', 'Never run out of battery with this high-capacity power bank.', 'Dual USB ports for charging multiple devices simultaneously.', 'Silver', '20000mAh', 49.99, 35, 'PowerTech', 1, 2, 0, 0, 1, CURRENT_TIMESTAMP);

INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Smartphone Stand', 'Hands-free viewing', 'Adjustable stand for smartphones, ideal for watching videos or video calls.', 'Sturdy and foldable design for portability.', 'White', 'One size', 14.99, 30, 'TechGear', 1, 2, 0, 0, 1, CURRENT_TIMESTAMP);

INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Flagship Smartphone', 'Cutting-edge technology', 'Experience the latest innovations with this flagship smartphone.', 'Advanced camera system for stunning photos and videos.', 'Blue', '6.4 inches', 1199.99, 10, 'Tech Innovations', 1, 1, 0, 0, 1, CURRENT_TIMESTAMP);

INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Budget-friendly Phone', 'Great value for money', 'A budget-friendly smartphone with essential features and reliable performance.', 'Available in various colors.', 'Black', '5.8 inches', 299.99, 20, 'ValueTech', 1, 1, 0, 0, 1, CURRENT_TIMESTAMP);


INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Wireless Charging Stand', 'Effortless charging', 'Charge your smartphone wirelessly with this sleek charging stand.', 'Compatible with Qi-enabled devices.', 'Black', 'One size', 34.99, 25, 'ChargeTech', 1, 2, 0, 0, 1, CURRENT_TIMESTAMP);

INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Car Mount Holder', 'Secure mounting solution', 'Mount your smartphone securely in your car for hands-free navigation and calls.', 'Adjustable grip fits most smartphones.', 'Gray', 'Universal', 24.99, 30, 'DriveTech', 1, 2, 0, 0, 1, CURRENT_TIMESTAMP);

INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Premium Flagship Phone', 'Top-tier performance', 'Experience the pinnacle of smartphone technology with this premium flagship model.', 'Ultra-fast processor and stunning OLED display.', 'Silver', '6.7 inches', 1499.99, 5, 'EliteTech', 1, 1, 0, 0, 1, CURRENT_TIMESTAMP);

INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Mid-range Smartphone', 'Balanced features', 'A mid-range smartphone offering a blend of performance and affordability.', 'Large battery capacity for all-day usage.', 'Green', '6.2 inches', 599.99, 15, 'TechSavvy', 1, 1, 0, 0, 1, CURRENT_TIMESTAMP);


INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Wireless Bluetooth Headset', 'Hands-free convenience', 'Enjoy wireless freedom with these lightweight Bluetooth headsets.', 'Built-in microphone for crystal-clear calls.', 'Black', 'One size', 79.99, 20, 'AudioGear', 1, 2, 0, 0, 1, CURRENT_TIMESTAMP);

INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Universal Phone Holder', 'Versatile mounting solution', 'Mount your smartphone on any surface with this adjustable holder.', '360-degree rotation for flexible viewing angles.', 'White', 'One size', 14.99, 25, 'MountTech', 1, 2, 0, 0, 1, CURRENT_TIMESTAMP);


INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Next-Gen Smartphone', 'Cutting-edge features', 'Experience the future of mobile technology with this advanced smartphone.', '5G connectivity and AI-powered camera.', 'Titanium', '6.8 inches', 1599.99, 5, 'Tech Titans', 1, 1, 0, 0, 1, CURRENT_TIMESTAMP);

INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Budget-Friendly Phone', 'Great value', 'An affordable smartphone with essential features at an unbeatable price.', 'Dual SIM support and expandable storage.', 'Rose Gold', '6.2 inches', 399.99, 10, 'ValueTech', 1, 1, 0, 0, 1, CURRENT_TIMESTAMP);


INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Bluetooth Wireless Earphones', 'Tangle-free listening', 'Enjoy wireless audio freedom with these sleek Bluetooth earphones.', 'Long battery life and comfortable fit.', 'Black', 'One size', 69.99, 15, 'AudioTech', 1, 2, 0, 0, 1, CURRENT_TIMESTAMP);

INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Car Phone Mount', 'Secure phone placement', 'Keep your phone safe and secure while driving with this sturdy car mount.', 'Adjustable grip fits most smartphones.', 'Silver', 'One size', 19.99, 20, 'DriveTech', 1, 2, 0, 0, 1, CURRENT_TIMESTAMP);

INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Premium Smartphone Plus', 'Ultimate performance', 'Experience unparalleled performance and luxury with this premium smartphone.', 'Quad-camera setup for professional-grade photography.', 'Midnight Blue', '6.9 inches', 1799.99, 5, 'LuxuryTech', 1, 1, 0, 0, 1, CURRENT_TIMESTAMP);

INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Compact Budget Phone', 'Compact and efficient', 'A compact budget phone with essential features and reliable performance.', 'Long-lasting battery for extended usage.', 'Charcoal Gray', '5.5 inches', 299.99, 10, 'AffordableTech', 1, 1, 0, 0, 1, CURRENT_TIMESTAMP);

INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Wireless Bluetooth Speaker', 'Immersive audio experience', 'Enjoy high-quality wireless audio with this portable Bluetooth speaker.', 'Water-resistant design for outdoor use.', 'Red', 'Medium', 99.99, 15, 'SoundTech', 1, 2, 0, 0, 1, CURRENT_TIMESTAMP);

INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Universal Car Charger', 'Fast charging on-the-go', 'Charge your devices quickly while driving with this universal car charger.', 'Multiple USB ports for simultaneous charging.', 'Black', 'One size', 29.99, 20, 'DriveTech', 1, 2, 0, 0, 1, CURRENT_TIMESTAMP);

INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Professional Grade Smartphone', 'Top-tier performance', 'Experience professional-grade performance with this high-end smartphone.', 'Super AMOLED display and advanced camera system.', 'Graphite', '6.7 inches', 1499.99, 5, 'ProTech', 1, 1, 0, 0, 1, CURRENT_TIMESTAMP);

INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Compact and Stylish Phone', 'Slim design', 'A compact smartphone with a stylish design and essential features.', 'Available in multiple color options.', 'Coral Pink', '5.8 inches', 499.99, 10, 'StyleTech', 1, 1, 0, 0, 1, CURRENT_TIMESTAMP);


INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Bluetooth Wireless Speaker', 'Portable entertainment', 'Enjoy your favorite music on the go with this portable Bluetooth speaker.', 'Compact size and long battery life.', 'Blue', 'Small', 79.99, 15, 'AudioTech', 1, 2, 0, 0, 1, CURRENT_TIMESTAMP);

INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Universal Phone Mount', 'Flexible mounting solution', 'Mount your smartphone securely in your car or at home with this versatile phone mount.', 'Adjustable design fits most smartphones.', 'Black', 'One size', 19.99, 20, 'MountTech', 1, 2, 0, 0, 1, CURRENT_TIMESTAMP);


INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate) 
VALUES ('Flagship Plus Smartphone', 'Top-tier performance', 'Experience the pinnacle of mobile technology with this flagship smartphone.', 'Quad-camera setup and 5G connectivity.', 'Mystic Black', '6.9 inches', 1699.99, 5, 'TechGurus', 1, 1, 0, 0, 1, CURRENT_TIMESTAMP);

INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate) 
VALUES ('Budget-Friendly Phone', 'Affordable option', 'An entry-level smartphone offering essential features at a budget-friendly price.', 'Available in multiple colors.', 'Ocean Blue', '6.2 inches', 399.99, 10, 'AffordableTech', 1, 1, 0, 0, 1, CURRENT_TIMESTAMP);


INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate) 
VALUES ('Wireless Charging Pad', 'Effortless charging', 'Charge your devices wirelessly with this sleek charging pad.', 'Compatible with Qi-enabled smartphones.', 'White', 'One size', 29.99, 15, 'ChargeTech', 1, 2, 0, 0, 1, CURRENT_TIMESTAMP);

INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate) 
VALUES ('Car Phone Holder', 'Secure mount', 'Keep your phone safe and stable while driving with this sturdy car phone holder.', 'Adjustable design fits most smartphones.', 'Black', 'One size', 14.99, 20, 'DriveTech', 1, 2, 0, 0, 1, CURRENT_TIMESTAMP);


INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Premium Flagship Smartphone', 'Ultimate performance', 'Experience top-tier performance with this premium flagship smartphone.', 'Ultra-high-resolution display and advanced camera features.', 'Graphite', '6.7 inches', 1499.99, 5, 'TechLux', 1, 1, 0, 0, 1, CURRENT_TIMESTAMP);

INSERT INTO Product (ProdName, ShortDesc, LongDesc, AdditionalDesc, Color, Size, Price, Quantity, CompanyName, CatId, SubCatId, Sold, IsCustomized, IsActive, CreatedDate)
VALUES ('Compact Budget Phone', 'Affordable option', 'A compact and affordable smartphone with essential features.', 'Long-lasting battery and expandable storage.', 'Silver', '5.5 inches', 399.99, 10, 'BudgetTech', 1, 1, 0, 0, 1, CURRENT_TIMESTAMP);






