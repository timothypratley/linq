(map inc [1 2 3 4])

(filter odd? [1 2 3 4])

(map inc (filter odd? [1 2 3 4]))
;; composition of functions

;; same thing data first, operation pipeline
(->> [1 2 3 4]
    (filter odd?)
    (map inc))

;; same thing but with named steps
(let [data [1 2 3 4]
      odds (filter odd? data)
      evens (map inc odds)]
  evens)

;; connect to a database
(ns linq.core
  (:use [korma.db]
        [korma.core])
  (:require [clojure.string :as string]))

(defdb tc {:classname "oracle.jdbc.driver.OracleDriver"
           :subprotocol "oracle"
           :subname "thin:@tpratleyw7:1521:TW"
           :user "tc_col_own"
           :password "tc_col_own"
           :naming {:keys string/upper-case
                    :fields string/upper-case}})

(defentity containers (table :container))

(select containers
        (aggregate (avg :weight) :average))

(->> (select containers
             (fields :container_no)
             (where {:weight [< 1]}))
     (take 5)
     first)


; SelectMany
(def lines ["an apple a day"
             "the quick brown fox"])
(mapcat (fn [line] (re-seq #"\w+" line))
        lines)


(defn fib-step [[a b]]
  [b (+ a b)])
(def fib-seq (map first (iterate fib-step [0 1])))
(take 5 fib-seq)
(take 5 (iterate fib-step [0 1]))


; Closure
(let [a (atom 3)]
  (defn f [x] (+ x @a))
  (defn inca [] (swap! a inc)))
(f 2)
(inca)
(f 2)
a   ; error! out of scope


(let [words ["the" "quick" "brown" "fox"]]
  (group-by count words))

;; the word for "aggregate" is reduce
(defn count-words [text]
  (let [words (re-seq #"\w+" text)]
    (reduce
     (fn [a word] (update-in a [word] (fnil inc 0)))
     {}
     words)))

(let [dict (count-words "the quick brown fox jumped over the quick brown quick chicken quick")]
  (dict "quick"))
