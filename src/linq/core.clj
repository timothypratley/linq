(ns linq.core
  (:use [korma.db]
        [korma.core]
        [incanter core charts stats])
  (:require [clojure.string :as string]))

(defdb tc {:classname "oracle.jdbc.driver.OracleDriver"
           :subprotocol "oracle"
           :subname "thin:@tpratleyw7:1521:TW"
           :user "tc_col_own"
           :password "tc_col_own"
           :naming {:keys string/upper-case
                    :fields string/upper-case}})

(defentity containers (table :container))




















;; .Select(x => x + 1)

(map inc [1 2 3 4])



;; .Where(x => x%2 == 0)

(filter odd? [1 2 3 4])



;; .Where(x => x%2 == 0).Select(x => x + 1)

(map inc (filter odd? [1 2 3 4]))



;; .GroupBy(w => w.Length)

(let [words ["the" "quick" "brown" "fox"]]
  (group-by count words))



;; sequence of functions zipped with the data

(map apply [+ min max] (repeat [1 2 3 4]))









;; querying data

(select containers
        (aggregate (avg :weight) :average))

(->> (select containers
             (where {:weight [< 1]})
             (order :container_no))
     (map :CONTAINER_NO)
;     (take 5)
;     (drop 2)
;     first
     )


;; plotting distribution of container weights

(view (histogram
       (map #(or (:WEIGHT %) -10)
            (select containers))))















;; SelectMany

(let lines ["an apple a day"
             "the quick brown fox"]
  (mapcat (fn [line]
            (re-seq #"\w+" line))
          lines))



;; Generate
(defn fib-step [[a b]]
  [b (+ a b)])
(def fib-seq (map first (iterate fib-step [0 1])))


(fib-step [0 1])

(take 5 (iterate fib-step [0 1]))

(take 5 fib-seq)
















;; Closure - a function which captures scope
(let [a (atom 3)]
  (defn adda [x]
    (+ x @a))
  (defn inca []
    (swap! a inc)))

(adda 2)
(inca)
(adda 2)
;a   ; error! out of scope























;; aggregate factorial
;; 1 * 2 * 3 * 4 == 24
(reduce * (range 1 5))



;; word counting
(def words (re-seq #"\w+" "the quick brown fox jumped over the quick brown quick chicken quick"))
words

(defn dict++ [m word]
  (update-in m [word] (fnil inc 0)))

(dict++ {} "foo")

(reduce dict++ {} words)
(reductions dict++ {} words)


















(defn random-normal []
  (reduce + -49.5 (repeatedly 100 rand)))

(random-normal)

(view (histogram
       (repeatedly 10000 random-normal)))



;; Random walk

(defn step [prev]
  (+ prev
     (* (random-normal)
        prev
        0.05)))

(view (line-chart
       (range 0 300)
       (take 300 (iterate step 1500))))











