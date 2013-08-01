class Worker
  def initialize(input)
    @in = input
    @p = 0
    @rule = {}
    @result = ["cd19900419@hotmail.com\n","\n"] 
  end

  def run
    @in.each do |line|
      if line == "\n"
        @p = @p + 1
      else
        case @p
        when 0
          a = line.split(' ')
          @rule[a[1]] = a[3]
        when 1
          b = line.split(" ")
          if (line.include? '+') || (line.include? '-')
            c = []
            b.each_with_index do |array,index|
              if array == '+' || array == '-'
                c.push(array)
              elsif !(array =~ /^[a-z]+$/)
                d = array.to_f
                unit = singularize(b[index+1])
                c.push( d * @rule[unit].to_f)
              end
            end
            c = eval(c.join)
          else
            unit = singularize(b[1])
            c = b[0].to_f * @rule[unit].to_f
          end
          c = format("%.2f",c)
          @result.push(c.to_s+" m\n")
        end
      end
    end 
  @result
  end

  def singularize(s)
      case s
      when 'miles'
        'mile'
      when 'yards'
        'yard'
      when 'inches'
        'inch'
      when 'feet'
        'foot'
      when 'faths'
        'fath'
      when 'furlongs'
        'furlong'
      else
        s
      end
  end

end

File.open("input.txt") do |file|
  new_work = Worker.new(file)
  @rs = new_work.run
end

file = File.new("output.txt","w")
@rs.each do |r|
  file.puts(r)
end 
