Array.prototype.insert = function(value, index) {
    var array = this;
    for(var i = array.length - 1; index <= i; i--){
        array[i + 1] = array[i]
    }
    array[index] = value
};

Array.prototype.insertBefore = function(from, to) {
    this.insert(this[from], to);
    if(to < from){
        from += 1
    }
    this.splice(from, 1)
};

new Vue({
    el: '#app',

    data: {
        internalValues: [],
        values: [],
        animationQueue: [],
        amount: 0,
        delay: 100,
        current: [],
        iterator: null
    },

    watch: {
        amount: function() {
            this.generateRandomData(this.amount)
        }
    },

    computed: {
        maxValue: function() {
            var max = Number.MIN_VALUE;

            for (var i = 0; i < this.internalValues.length; i++) {
                var value = this.internalValues[i];
                if (value > max) {
                    max = value;
                }
            }

            return max;
        }
    },

    methods: {
        // -----------------------------------------
        // Merge sort
        // -----------------------------------------
        mergeSort: function(first, last) {
            var array = this.internalValues;
            first = (first === undefined) ? 0 : first;
            last = (last === undefined) ? array.length - 1 : last;

            if (first == last) {
                return
            }

            var middle = Math.floor((first + last) / 2);
            this.mergeSort(first, middle);
            this.mergeSort(middle + 1, last);

            while (first <= middle && middle + 1 <= last) {
                this.highlight(first, middle + 1);

                if (array[first] >= array[middle + 1]) {
                    this.insertBefore(middle + 1, first);
                    middle++
                }
                first++
            }
        },

        insertBefore: function(from, to) {
            this.internalValues.insertBefore(from, to);
            this.highlight(from, to, this.values.insertBefore);
        },

        generateRandomData: function(amount) {
            this.internalValues.length = 0;
            this.values.length = 0;

            for (var i = 0; i < amount; i++) {
                this.internalValues.push(Math.floor(Math.random() * 100))
            }

            this.values = this.internalValues.slice();
        },

        reset: function() {
            this.animationQueue.length = 0;
            this.generateRandomData(this.amount)
        },

        start: function() {
            this.animationQueue.length = 0;
            this.mergeSort()
        },

        inArray: function(needle, haystack) {
            for (var i = 0; i < haystack.length; i++) {
                if (haystack[i] == needle) {
                    return true
                }
            }
            return false
        },

        highlight: function(pos1, pos2, method) {
            this.animationQueue.push({ method: method, elements: [pos1, pos2] });
        },

        queueNext: function() {
            if (this.animationQueue.length > 0) {
                var item = this.animationQueue[0];
                console.log(item);
                var elements = item.elements;

                this.current = elements;

                if (item.method !== undefined) {
                    item.method.apply(this.values, elements);
                }

                this.animationQueue.shift()
            } else {
                this.current = [];
            }
        },

        draw: function() {
            clearInterval(this.iterator);

            this.queueNext();

            this.iterator = setInterval(this.draw, this.delay);
        }
    },

    mounted: function() {
        this.amount = 50;

        this.draw();
    }
})