openssl ecparam -list_curves
openssl ecparam -name prime256v1 -genkey -noout -out ecc-private-key.pem
openssl ec -in ecc-private-key.pem -text -noout  