(ns linq.core-test
  (:use clojure.test
        clojure.java.jdbc))

(def db {:classname "oracle.jdbc.driver.OracleDriver"
         :subprotocol "oracle"
         :subname "thin:@tpratleyw7:1521:TW"
         :user "tc_col_own"
         :password "tc_col_own"})

(deftest a-test
  (with-connection db
     (with-query-results rs ["select * from container"]
       (doseq [r (first rs)]
         (println r)))))